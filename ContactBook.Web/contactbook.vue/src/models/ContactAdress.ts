export default class adresses {
    id:number;
    contactId:number;
    street:string;
    houseNumber:string;
    city:string;
    lat:number;
    lng:number;
    type:AdressType

    constructor (id:number, contactId:number, street:string, houseNumber:string, city:string, type:AdressType, lat:number, lng:number) {
      this.id = id
      this.contactId = contactId
      this.street = street
      this.houseNumber = houseNumber
      this.city = city
      this.type = type
      this.lat = lat
      this.lng = lng
    }
}
export enum AdressType{
    Home,
    Work
}
