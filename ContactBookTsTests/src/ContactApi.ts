import {AxiosResponse} from 'axios'
import {contactsClient} from './axios'
import https = require('https')
import Contact from './models/Contact'

const agent = new https.Agent({  
    rejectUnauthorized: false
  });
export class ContactApi{
    static async clearContacts(): Promise<AxiosResponse<void>> {
        return contactsClient.delete('contacts/clear' ,{ httpsAgent: agent })
    }
    static async addContact(req:Contact): Promise<AxiosResponse<Contact>> {
        return contactsClient.put('contacts',req,{ httpsAgent: agent })
    }
}