export default class phones
{
    id:number;
    contactId:number;
    phoneNumber:string;
    type:number;

    constructor(id:number,contactId:number,phoneNumber:string,type:number)
    {
        this.id = id,
        this.contactId = contactId,
        this.phoneNumber = phoneNumber,
        this.type = type
    }
}
export enum PhoneType{
    Home,
    Work,
    MobilePhone
}