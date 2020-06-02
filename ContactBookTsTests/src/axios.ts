import axios from 'axios'

export const contactsClient = axios.create({
    baseURL: 'https://localhost:44382/api/'
});

