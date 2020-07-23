using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using  Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.Core.Util{

public
class ContactCoreFactory : CompanyCoreFactory{

protected
ContactCoreFactory() : base(){
}

public
Contact createContact(){
	ContactsSonsDataBaseContainer contactsSonsDataBaseContainer = new ContactsSonsDataBaseContainer(this.dataBaseAccess);
	ContactsEmailsDataBaseContainer contactsEmailsDataBaseContainer = new ContactsEmailsDataBaseContainer(this.dataBaseAccess);

	return new Contact(contactsSonsDataBaseContainer, contactsEmailsDataBaseContainer);
}

public
bool existsContact(int id){
	try{
		ContactDataBase contactDataBase = new ContactDataBase(dataBaseAccess);

		contactDataBase.setCNT_Id(id);
		
		return contactDataBase.exists();
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
Contact readContact(int id){
    try{		
		ContactDataBase contactDataBase = new ContactDataBase(dataBaseAccess);

		contactDataBase.setCNT_Id(id);
		if (!contactDataBase.exists())
			return null;
		contactDataBase.read();

		ContactsEmailsDataBaseContainer contactsEmailsDataBaseContainer = new ContactsEmailsDataBaseContainer(dataBaseAccess);
		contactsEmailsDataBaseContainer.readById(id);

		ContactsSonsDataBaseContainer contactsSonsDataBaseContainer = new ContactsSonsDataBaseContainer(dataBaseAccess);
		contactsSonsDataBaseContainer.readById(id);

		Contact contact = this.objectDataBaseToObject(contactDataBase);
		contact.setContactsEmailsDataBaseContainer(contactsEmailsDataBaseContainer);
		contact.setContactsSonsDataBaseContainer(contactsSonsDataBaseContainer);
		
		return contact;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateContact(Contact contact){
   try{
   
        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        
        ContactDataBase contactDataBase = this.objectToObjectDataBase(contact);
        contactDataBase.update();

		ContactsEmailsDataBaseContainer forDelete1 = new ContactsEmailsDataBaseContainer(dataBaseAccess);
		forDelete1.readById(contact.getContactId());
		forDelete1.delete();

		ContactsSonsDataBaseContainer forDelete2 = new ContactsSonsDataBaseContainer(dataBaseAccess);
		forDelete2.readById(contact.getContactId());
		forDelete2.delete();

		ContactsEmailsDataBaseContainer contactsEmailsDataBaseContainer = contact.getContactsEmailsDataBaseContainer();
		contactsEmailsDataBaseContainer.write();

		ContactsSonsDataBaseContainer contactsSonsDataBaseContainer = contact.getContactsSonsDataBaseContainer();
		contactsSonsDataBaseContainer.write();
	   
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
  
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writeContact(Contact contact){
   try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        
        ContactDataBase contactDataBase = this.objectToObjectDataBase(contact);
        contactDataBase.write();

		ContactsEmailsDataBaseContainer contactsEmailsDataBaseContainer = contact.getContactsEmailsDataBaseContainer();
		for(int i = 0; i < contactsEmailsDataBaseContainer.Count; i++){
			ContactsEmailsDataBase contactsEmailsDataBase = (ContactsEmailsDataBase)contactsEmailsDataBaseContainer[i];
			contactsEmailsDataBase.setCE_ContactId(contactDataBase.getCNT_Id());
			contactsEmailsDataBase.write();
		}

		ContactsSonsDataBaseContainer contactsSonsDataBaseContainer = contact.getContactsSonsDataBaseContainer();
		for(int i = 0; i < contactsSonsDataBaseContainer.Count; i++){
			ContactsSonsDataBase contactsSonsDataBase = (ContactsSonsDataBase)contactsSonsDataBaseContainer[i];
			contactsSonsDataBase.setCE_ContactId(contactDataBase.getCNT_Id());
			contactsSonsDataBase.write();
		}
	   
		contact.setContactId(contactDataBase.getCNT_Id());

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
   }catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
bool canDeleteContact(Contact contact){
   try{
	 return true;
   }catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void deleteContact(Contact contact){
   try{
       if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        
        ContactDataBase contactDataBase = this.objectToObjectDataBase(contact);
        contactDataBase.delete();

		ContactsEmailsDataBaseContainer contactsEmailsDataBaseContainer = contact.getContactsEmailsDataBaseContainer();
		contactsEmailsDataBaseContainer.delete();

		ContactsSonsDataBaseContainer contactsSonsDataBaseContainer = contact.getContactsSonsDataBaseContainer();
		contactsSonsDataBaseContainer.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
  
   }catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

private
Contact objectDataBaseToObject(ContactDataBase contactDataBase){
	Contact contact = this.createContact();

	contact.setContactId(contactDataBase.getCNT_Id());
	contact.setFirstName(contactDataBase.getCNT_FirstName());
	contact.setSecondName(contactDataBase.getCNT_SecondName());
	contact.setLastName(contactDataBase.getCNT_LastName());
	contact.setNickName(contactDataBase.getCNT_NickName());
	contact.setDisplayName(contactDataBase.getCNT_DisplayName());
	contact.setTitle(contactDataBase.getCNT_Title());
	contact.setAddress(contactDataBase.getCNT_Address());
	contact.setCity(contactDataBase.getCNT_City());
	contact.setState(contactDataBase.getCNT_State());
	contact.setZipCode(contactDataBase.getCNT_ZipCode());
	contact.setCountry(contactDataBase.getCNT_Country());
	contact.setPhone(contactDataBase.getCNT_Phone());
	contact.setFax(contactDataBase.getCNT_Fax());
	contact.setMobile(contactDataBase.getCNT_Mobile());
	contact.setOrganization(contactDataBase.getCNT_Organization());
	contact.setOffice(contactDataBase.getCNT_Office());
	contact.setJobAddress(contactDataBase.getCNT_JobAddress());
	contact.setJobCity(contactDataBase.getCNT_JobCity());
	contact.setJobState(contactDataBase.getCNT_JobState());
	contact.setJobZipCode(contactDataBase.getCNT_JobZipCode());
	contact.setJobCountry(contactDataBase.getCNT_JobCountry());
	contact.setJobPhone(contactDataBase.getCNT_JobPhone());
	contact.setJobFax(contactDataBase.getCNT_JobFax());
	contact.setJobPosition(contactDataBase.getCNT_JobPosition());
	contact.setJobDepartament(contactDataBase.getCNT_JobDepartament());
	contact.setJobLocalizator(contactDataBase.getCNT_JobLocalizator());
	contact.setJobIpPhone(contactDataBase.getCNT_JobIpPhone());
	
	contact.setConyugue(contactDataBase.getCNT_Conyugue());
	contact.setBirthday(contactDataBase.getCNT_Birthday());
	contact.setAnniversary(contactDataBase.getCNT_Anniversary());
	
	contact.setNotes(contactDataBase.getCNT_Notes());
	contact.setSex(contactDataBase.getCNT_Sex());

	return contact;
//	contact.setSons(contactDataBase.getContactSonsDataBaseContainer());
//	contact.setEmailDataBaseContainer(contactDataBase.getEmailDataBaseContainer());
}

private
ContactDataBase objectToObjectDataBase(Contact contact){	
	ContactDataBase contactDataBase = new ContactDataBase(dataBaseAccess);
		
	contactDataBase.setCNT_Id(contact.getContactId());
	contactDataBase.setCNT_FirstName(contact.getFirstName());
	contactDataBase.setCNT_SecondName(contact.getSecondName());
	contactDataBase.setCNT_LastName(contact.getLastName());
	contactDataBase.setCNT_NickName(contact.getNickName());
	contactDataBase.setCNT_DisplayName(contact.getDisplayName());
	contactDataBase.setCNT_Title(contact.getTitle());
	contactDataBase.setCNT_Address(contact.getAddress());
	contactDataBase.setCNT_City(contact.getCity());
	contactDataBase.setCNT_State(contact.getState());
	contactDataBase.setCNT_ZipCode(contact.getZipCode());
	contactDataBase.setCNT_Country(contact.getCountry());
	contactDataBase.setCNT_Phone(contact.getPhone());
	contactDataBase.setCNT_Fax(contact.getFax());
	contactDataBase.setCNT_Mobile(contact.getMobile());
	contactDataBase.setCNT_Organization(contact.getOrganization());
	contactDataBase.setCNT_Office(contact.getOffice());
	contactDataBase.setCNT_JobAddress(contact.getJobAddress());
	contactDataBase.setCNT_JobCity(contact.getJobCity());
	contactDataBase.setCNT_JobState(contact.getJobState());
	contactDataBase.setCNT_JobZipCode(contact.getJobZipCode());
	contactDataBase.setCNT_JobCountry(contact.getJobCountry());
	contactDataBase.setCNT_JobPhone(contact.getJobPhone());
	contactDataBase.setCNT_JobFax(contact.getJobFax());
	contactDataBase.setCNT_JobPosition(contact.getJobPosition());
	contactDataBase.setCNT_JobDepartament(contact.getJobDepartament());
	contactDataBase.setCNT_JobLocalizator(contact.getJobLocalizator());
	contactDataBase.setCNT_JobIpPhone(contact.getJobIpPhone());
	contactDataBase.setCNT_Conyugue(contact.getConyugue());
	contactDataBase.setCNT_Birthday(contact.getBirthday());
	contactDataBase.setCNT_Anniversary(contact.getAnniversary());
	contactDataBase.setCNT_Notes(contact.getNotes());
	contactDataBase.setCNT_Sex(contact.getSex());

	return contactDataBase;
}

public 
string[][] getContactsByDesc(string searchText){
	try{
		ContactDataBaseContainer contactDataBaseContainer = new ContactDataBaseContainer(dataBaseAccess);
		contactDataBaseContainer.readByDesc(searchText);

		string[][] vec = new string[contactDataBaseContainer.Count][];

		for(int i = 0; i < contactDataBaseContainer.Count; i++){
			ContactDataBase contactDataBase = (ContactDataBase) contactDataBaseContainer[i];

			string[] line = new string[4];
			line[0] = contactDataBase.getCNT_Id().ToString();
			line[1] = contactDataBase.getCNT_FirstName();
			line[2] = contactDataBase.getCNT_SecondName();
			line[3] = contactDataBase.getCNT_LastName();
			vec[i] = line;
		}

		return vec;
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

} // class

} // namespace