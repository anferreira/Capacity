using System;

namespace GridScheduling.gui.Model
{

	public abstract class DateListNode
	{
		private DateListNode next;
		private DateListNode previous;

		public DateListNode()
		{
			next = null;
			previous = null;
		}

		public DateListNode getPrevious(){
			return previous;
		}

		public DateListNode getNext(){
			return next;
		}

		public void setPrevious (DateListNode previousNode)
		{
			previous = previousNode;
			if (previous != null)
				if ((previous.getNext() == null) || (!previous.getNext().Equals(this)))
					previous.setNext(this);
		}

		public void setNext (DateListNode nextNode)
		{
			next = nextNode;
			if (next != null)
				if ((next.getPrevious() == null) || (!next.getPrevious().Equals(this)))
					next.setPrevious(this);
		}

		public abstract DateTime getDate();
	}
}
