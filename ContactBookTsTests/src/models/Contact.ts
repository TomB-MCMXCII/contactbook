import {ContactAdress} from "./ContactAdress"
import {ContactPhone} from "./ContactPhone"
import {ContactEmail} from "./ContactEmail"

export class Contact{
    id:number;
    Name:string;
    LastName:string;
    Company:string;
    Notes:string;
    DateOfBirth:string;
    Adresses:ContactAdress[];
    Phones:ContactPhone[];
    Emails:ContactEmail[];
}
