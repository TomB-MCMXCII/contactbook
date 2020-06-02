import axios from 'axios'
import ContactAdress from './models/ContactAdress'
// axios.defaults.baseURL = 'https://maps.googleapis.com/maps/api/geocode/json?address='
const customAxios = axios.create({
  baseURL: 'https://maps.googleapis.com/maps/api/geocode/json?address='
})

// https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyBwQ2LExakaRef1nyW65VGANB4UhPHl5n0
export default class ContactService {
  validateAdress (street:string, city:string, housenumber?:string) {
    return customAxios.post(`${street}${housenumber}${city}&key=AIzaSyBwQ2LExakaRef1nyW65VGANB4UhPHl5n0`)
  }
}
