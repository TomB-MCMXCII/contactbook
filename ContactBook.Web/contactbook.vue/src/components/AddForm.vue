<template>
<div class="container-fluid">
  <form v-if="!loading" class="form" v-on:submit="onSubmit">
    <div class="basic-info">
  <div class="form-row">
    <div class="col-md-2 mb-3">
      <input type="text-field" class="form-control " id="validationServer01" placeholder="First name" value="Mark" required
      v-model="name">
    </div>
    <div class="col-md-2 mb-3">
      <input type="text-field" class="form-control " id="validationServer02" placeholder="Last name" value="Otto" required
      v-model="lastname">
    </div>
    <div class="col-md-2 mb-3">
      <input type="text-field" class="form-control " id="validationServer02" placeholder="Company" value="Facebook"
      v-model="company">
    </div>
  </div>
  <div class="form-row">
    <div class="col-md-4 mb-3">
      <input type="text-area" class="form-control " id="validationServer01" placeholder="Notes"
      v-model="notes">
    </div>
    <div class="col-md-3 mb-3">
      <input type="text-field" class="form-control " id="validationServer01" placeholder="dd/mm/yyyy"
      v-model="dateOfBirth">
    </div>
  </div>
  </div>
  <div class="form-row phone-row">
    <div class="col-md-2 mb-1">
      <!-- <label for="validationServer03">Phone number</label> -->
      <input type="text-field" class="form-control " id="validationServer01" placeholder="Phone number" pattern="\d+" minlength="8" maxlength="8"
      v-model="phones[0].phoneNumber">
    </div>
          <div class="col-md-2 mb-4">
            <!-- <label for="exampleFormControlSelect1">Type</label> -->
            <select class="form-control type" id="exampleFormControlSelect1"
            v-model="phones[0].type">
              <option value="0">Home</option>
              <option value="1">Work</option>
              <option value="2">Mobile phone</option>
            </select>
          </div>
    <div class="col-md-2 mb-1">
      <!-- <label for="validationServer03">Phone number</label> -->
      <input type="text-field" class="form-control " id="validationServer01" placeholder="Phone number" pattern="\d+" minlength="8" maxlength="8"
      v-model="phones[1].phoneNumber">
    </div>
     <div class="col-md-2 mb-2">
            <!-- <label for="exampleFormControlSelect1">Type</label> -->
            <select class="form-control type" id="exampleFormControlSelect1"
            v-model="phones[1].type">
              <option value="0">Home</option>
              <option value="1">Work</option>
              <option value="2">Mobile phone</option>
            </select>
          </div>
    <div class="col-md-2 mb-1">
      <!-- <label for="validationServer03">Phone number</label> -->
      <input type="text-field" class="form-control " id="validationServer01" placeholder="Phone number" pattern="\d+" minlength="8" maxlength="8"
      v-model="phones[2].phoneNumber">
    </div>
     <div class="col-md-2 mb-2">
            <!-- <label for="exampleFormControlSelect1">Type</label> -->
            <select class="form-control type" id="exampleFormControlSelect1"
            v-model="phones[0].type">
              <option value="0">Home</option>
              <option value="1">Work</option>
              <option value="2">Mobile phone</option>
            </select>
          </div>
  </div>
  <div class="form-row email-row">
    <div class="col-md-2 mb-4">
      <!-- <label for="validationServer03">Email</label> -->
      <input type="text-field" class="form-control " id="validationServer01" placeholder="Email" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$"
      v-model="emails[0].email">
    </div>
    <div class="col-md-2 mb-4">
            <!-- <label for="exampleFormControlSelect1">Type</label> -->
            <select class="form-control type" id="exampleFormControlSelect1"
            v-model="emails[0].type">
              <option value="0">Personal</option>
              <option value="1">Work</option>
            </select>
          </div>
    <div class="col-md-2 mb-4">
      <!-- <label for="validationServer03">Email</label> -->
      <input type="text-field" class="form-control" id="validationServer01" placeholder="Email" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$"
      v-model="emails[1].email">
    </div>
    <div class="col-md-2 mb-4">
            <!-- <label for="exampleFormControlSelect1">Type</label> -->
            <select class="form-control type" id="exampleFormControlSelect1"
            v-model="emails[1].type">
              <option value="0">Personal</option>
              <option value="1">Work</option>
            </select>
          </div>
    <div class="col-md-2 mb-4">
      <!-- <label for="validationServer03">Email</label> -->
      <input type="text-field" class="form-control" id="validationServer01" placeholder="Email" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$"
      v-model="emails[2].email">
    </div>
    <div class="col-md-2 mb-4">
            <!-- <label for="exampleFormControlSelect1">Type</label> -->
            <select class="form-control type" id="exampleFormControlSelect1"
            v-model="emails[2].type">
              <option value="0">Personal</option>
              <option value="1">Work</option>
            </select>
          </div>
  </div>
  <div class="form-row address-row">
    <div class="col-md-4 mb-2">
      <!-- <label for="validationServer03">Adress</label> -->
      <input type="text-field" class="form-control " id="validationServer01" placeholder="Street"
      v-model="adresses[0].street">
      <input type="text-field" class="form-control " id="validationServer01" placeholder="House number"
      v-model="adresses[0].houseNumber">
      <input type="text-field" class="form-control " id="validationServer01" placeholder="City"
      v-model="adresses[0].city">
    </div>
    <div class="col-md-4 mb-2">
      <!-- <label for="validationServer03">Adress</label> -->
      <input type="text-field" class="form-control " id="validationServer01" placeholder="Street"
      v-model="adresses[1].street">
      <input type="text-field" class="form-control " id="validationServer01" placeholder="House number"
      v-model="adresses[1].houseNumber">
      <input type="text-field" class="form-control " id="validationServer01" placeholder="City"
      v-model="adresses[1].city">
    </div>
    <div class="col-md-4 mb-1">
      <!-- <label for="validationServer03">Adress</label> -->
      <input type="text-field" class="form-control " id="validationServer01" placeholder="Street"
      v-model="adresses[2].street">
      <input type="text-field" class="form-control " id="validationServer01" placeholder="House number"
      v-model="adresses[2].houseNumber">
      <input type="text-field" class="form-control " id="validationServer01" placeholder="City"
      v-model="adresses[2].city">
    </div>
  </div>
  <button class="btn btn-primary" type="submit">Add</button>
</form>
<div class="progress" v-else-if="loading">
      <div class="indeterminate"></div>
  </div>
 </div>
</template>

<script lang="ts">
import Vue from 'vue'
import ContactService from '../ContactService'
import Contact from '../models/Contact'
import ContactPhone from '../models/ContactPhone'
import ContactEmail from '../models/ContactEmail'
import ContactAdress from '../models/ContactAdress'
import AddPhones from './AddPhones.vue'
const contactService = new ContactService()
export default Vue.extend({
  name: 'AddForm',
  data () {
    return {
      loading: false,
      name: '',
      lastname: '',
      company: '',
      dateOfBirth: '',
      notes: '',
      status: 0,
      phones: [{
        id: 0,
        contactId: 0,
        phoneNumber: '',
        type: 0
      },
      {
        id: 0,
        contactId: 0,
        phoneNumber: '',
        type: 0
      },
      {
        id: 0,
        contactId: 0,
        phoneNumber: '',
        type: 0
      }],
      emails: [{
        id: 0,
        contactId: 0,
        email: '',
        type: 0
      },
      {
        id: 0,
        contactId: 0,
        email: '',
        type: 0
      },
      {
        id: 0,
        contactId: 0,
        email: '',
        type: 0
      }],
      adresses: [{
        id: 0,
        contactId: 0,
        street: '',
        houseNumber: '',
        city: '',
        type: 0,
        lat: 0,
        lng: 0
      },
      {
        id: 0,
        contactId: 0,
        street: '',
        houseNumber: '',
        city: '',
        type: 0,
        lat: 0,
        lng: 0
      },
      {
        id: 0,
        contactId: 0,
        street: '',
        houseNumber: '',
        city: '',
        type: 0,
        lat: 0,
        lng: 0
      }
      ]
    }
  },
  methods: {
    onSubmit () {
      this.loading = true
      let phones:ContactPhone[] = this.phones.filter(phones => phones.phoneNumber !== '')
      let emails:ContactEmail[] = this.emails.filter(emails => emails.email !== '')
      let adresses:ContactAdress[] = this.adresses.filter(adresses => adresses.street !== '' && adresses.city !== '')
      const contact = new Contact(0, this.name, this.lastname, this.company, this.dateOfBirth, this.notes, phones, emails, adresses)
      contactService.writeContact(contact)
        .then(res => {
          console.log(res)
          this.loading = false
        })
        .catch(err => console.error(err))
    }
  },
  watch: {
    loading (loading) {
      this.loading = loading
    }
  }
})
</script>
<style lang="scss" scoped>
form{
  font-size: 0px;
}
.form-control{
  font-size: 10px;
}
.type{
  width:100px;
}
form{
  label{
    font-size: 10px;
  }
}
input:invalid {
  border: 2px dashed red;
}
.basic-info, .phone-row, .email-row, .address-row{
    border: solid black 1px;
    border-radius: 10px;
    padding: 10px;
    margin-bottom: 10px;
}
.btn{
    position: relative;
    top: 11.2rem;
}
</style>
