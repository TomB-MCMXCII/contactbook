import axios from 'axios'
import Contact from './models/Contact'
import ContactPhone from './models/ContactPhone'
import ContactEmail from './models/ContactEmail'
import ContactAdress from './models/ContactAdress'
axios.defaults.baseURL = 'https://localhost:44382/api'

export default class ContactService {
  getAllContacts () {
    return axios.get(`/contacts`)
  }
  writeContact (contact:Contact) {
    return axios.put(`/contacts`, contact)
  }
  deleteContact (id:number) {
    return axios.delete(`/contacts?id=${id}`)
  }
  updateContact (contact:Contact) {
    return axios.post(`/contacts`, contact)
  }
  updatePhone (phone:ContactPhone) {
    return axios.post('contacts/phone', phone)
  }
  updateEmail (email:ContactEmail) {
    return axios.post('contacts/email', email)
  }
  updateAdress (adress:ContactAdress) {
    return axios.post('contacts/adress', adress)
  }
  searchByName (name:string) {
    return axios.get(`/contacts/search?name=${name}`)
  }
  searchByLastname (lastname:string) {
    return axios.get(`/contacts/search?lastname=${lastname}`)
  }
  searchByCompany (company:string) {
    return axios.get(`/contacts/search?company=${company}`)
  }
  searchByPhone (phone:string) {
    return axios.get(`/contacts/search?phone=${phone}`)
  }
  searchByEmail (email:string) {
    return axios.get(`/contacts/search?email=${email}`)
  }
}
