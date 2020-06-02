import Contact from "../models/Contact"
import ContactAdress from "../models/ContactAdress"
import ContactPhone from "../models/ContactPhone"
import ContactEmail from "../models/ContactEmail"

  const Adress = new ContactAdress('Zemgales iela','42','Jurmala',2);
  const Phone = new ContactPhone('23454324',2)
  const Email = new ContactEmail('fala@inbox.lv',1);
  let adresses:ContactAdress[]
  let phones:ContactPhone[]
  let emails:ContactEmail[]
  adresses = [Adress]
  phones = [Phone]
  emails = [Email]
  
  const contact = new Contact(0,'Tomass','Blanks','Forum','blablabla','25/07/1992',adresses,phones,emails)
  export {contact}