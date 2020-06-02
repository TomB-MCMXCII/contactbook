export default class emails{
    id:number;
    contactId:number;
    email:string;
    type:EmailType;

    constructor(id:number,contactId:number,email:string,type:EmailType)
    {
        this.id = id,
        this.contactId = contactId,
        this.email = email,
        this.type = type
    }
}
export enum EmailType{
    Home,
    Work
}