import {Contact} from "../models/Contact"
import {ContactAdress} from "../models/ContactAdress"
import {ContactPhone} from "../models/ContactPhone"
import {ContactEmail} from "../models/ContactEmail"
import { request } from "http"


  const Adress = new ContactAdress();
  const Phones = new ContactPhone()
  const Email = new ContactEmail();
  
  

describe("Snake", () => {
  it("should take three cells at the beginning", () => {
    const Http = new XMLHttpRequest();
    const url='https://jsonplaceholder.typicode.com/posts';
    Http.open("GET", url);
    Http.send();
    
    Http.onreadystatechange = (e) => {
      console.log(Http.responseText)
    }
     // expect().toEqual()
      //expect().toEqual()
  })

})
