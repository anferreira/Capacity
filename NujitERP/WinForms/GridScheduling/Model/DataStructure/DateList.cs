using System;
using System.Collections;

namespace GridScheduling.gui.Model
{

	public class DateList
	{

		Hashtable hash;
		DateTime firstDay;
		DateTime lastDay;

		public DateList()
		{
			hash = new Hashtable();
			firstDay = DateTime.MaxValue;
			lastDay = DateTime.MinValue;
		}

		public void add (DateListNode node)
		{
			node.setNext(null);
			node.setPrevious(null);

			DateTime date = node.getDate().Date;
			SortedList list = (SortedList)hash[date]; // Search for the list for the respective date
			if (list == null) // If there isn't one already, create one.
			{
				list = new SortedList();
				hash.Add (date,list); // And add it to the hash.
			}
			list.Add (node.getDate(),node); // Proceed to add the node to the list.
			setPreviousNode (node, list);
			setNextNode (node, list);
		}

		private void setPreviousNode (DateListNode node, SortedList list)
		{
			DateTime date = node.getDate().Date;
			if (date.CompareTo(firstDay) < 0)
				firstDay = date;
			else
			{
				int index = list.IndexOfKey(node.getDate());
				if (index > 0)
					node.setPrevious((DateListNode)list.GetByIndex(index - 1));
				else
				{
					if (!date.Equals(firstDay))
					{
						SortedList auxSL = this.getPreviousList(date);
						node.setPrevious((DateListNode)auxSL.GetByIndex(auxSL.Count - 1));
					}
				}
			}
		}

		private void setNextNode (DateListNode node, SortedList list)
		{
			DateTime date = new DateTime(node.getDate().Year, node.getDate().Month, node.getDate().Day);
			if (date.CompareTo(lastDay) > 0)
				lastDay = date;
			else
			{
				int index = list.IndexOfKey(node.getDate());
				if (index < (list.Count - 1))
					node.setNext((DateListNode)list.GetByIndex(index + 1));
				else
				{
					if (!date.Equals(lastDay))
					{
						SortedList auxSL = this.getNextList(date);
						node.setNext((DateListNode)auxSL.GetByIndex(0));
					}
				}
			}
		}

		private SortedList getPreviousList (DateTime date)
		{
			date = date.AddDays(-1);
			SortedList auxList = (SortedList)hash[date];
			while ((date.CompareTo(firstDay) >= 0) && (auxList == null))
			{
				date = date.AddDays (-1);
				auxList = (SortedList)hash[date];
			}
			if (date.CompareTo(firstDay) < 0)
				return null;
			else
				return auxList;
		}

		private SortedList getNextList (DateTime date)
		{
			date = date.AddDays(1);
			SortedList auxList = (SortedList)hash[date];
			while ((date.CompareTo(lastDay) <= 0) && (auxList == null))
			{
				date = date.AddDays (1);
				auxList = (SortedList)hash[date];
			}
			if (date.CompareTo(lastDay) > 0)
				return null;
			else
				return auxList;
		}

		public bool remove (DateListNode node)
		{
			SortedList list = (SortedList)hash[node.getDate().Date];
			if (list == null)
				return false;
			else
			{
				int index = list.IndexOfKey (node.getDate());
				if (index == -1)
					return false;
				else
				{
					node = (DateListNode)list.GetByIndex(index);
					
					if (node.getPrevious() == null)
					{
						if (node.getNext() != null)
							firstDay = node.getNext().getDate().Date;
						else
							firstDay = DateTime.MaxValue;
					}

					if (node.getNext() == null)
					{
						if (node.getPrevious() != null)
							lastDay = node.getPrevious().getDate().Date;
						else
							lastDay = DateTime.MinValue;
					}

					if (node.getPrevious() != null)
						node.getPrevious().setNext(node.getNext());
					else if (node.getNext() != null)
							node.getNext().setPrevious(null);
					list.RemoveAt(index);
					if (list.Count <= 0)
						hash.Remove(node.getDate().Date);
					return true;
				}
			}
		}

		public DateListNode getNode (DateTime date)
		{
			SortedList list = (SortedList)hash[date.Date];
			if (list != null)
				return (DateListNode)list[date];
			else
				return null;
		}

		public DateListNode getLastNode (DateTime limit)
		{
			SortedList list = (SortedList)hash[limit.Date];
			if (list != null)
			{
				int index = searchForNode (list, limit);
				if (index >= 0)
					return (DateListNode)list.GetByIndex(index);
			}

			list = getPreviousList(limit.Date);
			if (list != null)
				return (DateListNode)list.GetByIndex(list.Count-1);
			else
				return null;
		}

		public DateListNode getFirstNode (DateTime minimum)
		{
			SortedList list = (SortedList)hash[minimum.Date];
			if (list != null)
			{
				int index = searchForNode (list, minimum);
				if (index >= 0)
					return (DateListNode)list.GetByIndex(index);
				else
					return (DateListNode)list.GetByIndex(0);
			}
			else
			{
				list = getNextList(minimum.Date);
				if (list != null)
					return (DateListNode)list.GetByIndex(0);
				else
					return null;
			}
		}

		private int searchForNode (SortedList list, DateTime key)
		{
			return searchForNode (list, key, 0, list.Count - 1);
		}

		private int searchForNode (SortedList list, DateTime key, int first, int last)
		{
			if (last <= first)
			{
				if ((((DateListNode)list.GetByIndex(first)).getDate().Equals(key)) || (((DateListNode)list.GetByIndex(first)).getDate().CompareTo(key) < 0))
					return first;
				else
					return first - 1;
			}
			int index = (last + first) / 2;
			if (((DateListNode)list.GetByIndex(index)).getDate().Equals(key))
				return index;
			else if (((DateListNode)list.GetByIndex(index)).getDate().CompareTo(key) < 0)
				return searchForNode (list, key, index + 1, last);
			else
				return searchForNode (list, key, first, index - 1);
		}

		public IEnumerator getEnumerator()
		{
			return hash.Values.GetEnumerator();
		}

		public DateListNode getLastNode()
		{
			if (lastDay.Equals(DateTime.MinValue))
				return null;
			else
			{
				SortedList sl = (SortedList)hash[lastDay];
				return (DateListNode)sl.GetByIndex(sl.Count-1);
			}
		}

		public DateListNode getFirstNode()
		{
			if (firstDay.Equals(DateTime.MaxValue))
				return null;
			else
			{
				SortedList sl = (SortedList)hash[firstDay];
				return (DateListNode)sl.GetByIndex(0);
			}
		}

	}
}
