import ContactPhone from './ContactPhone'
import ContactEmail from './ContactEmail'
import ContactAdress from './ContactAdress'

export default class Contact {
    id:number;
    name:string;
    lastName:string;
    company:string;
    dateOfBirth:string;
    notes:string;
    phones:ContactPhone[];
    emails:ContactEmail[];
    adresses:ContactAdress[];
    constructor (id:number, name:string, lastName:string, company:string, dateOfBirth:string,
      notes:string, ContactPhones:ContactPhone[], ContactEmails:ContactEmail[], ContactAdresses:ContactAdress[]) {
      this.id = id
      this.name = name
      this.lastName = lastName
      this.company = company
      this.dateOfBirth = dateOfBirth
      this.notes = notes
      this.phones = ContactPhones
      this.emails = ContactEmails
      this.adresses = ContactAdresses
    }
}
