<template>
 <div class="container-fluid form-wrapper">
        <form v-if="!loading" class="form" v-on:submit="onUpdate">
        <div class="form-row">
            <div class="col-md-6 mb-3">
                <label for="validationServer01">First name</label>
                <input type="text-field" class="form-control " placeholder="First name" value="Mark" required
                v-model="name">
            </div>
            <div class="col-md-4 mb-3">
                <label for="validationServer02">Last name</label>
                <input type="text-field" class="form-control " placeholder="Last name" value="Otto" required
                v-model="lastname">
            </div>
            <div class="col-md-4 mb-3">
                <label for="validationServer02">Company</label>
                <input type="text-field" class="form-control " placeholder="Company" value="Facebook"
                v-model="company">
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-7 mb-3">
                <label for="validationServer03">Notes</label>
                <input type="text-field" class="form-control"  placeholder="Notes"
                v-model="notes">
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-6 mb-3">
                <label for="validationServer03">Date of birth</label>
                <input type="date" class="form-control"
                v-model="dateOfBirth">
            </div>
        </div>
        <button class="btn btn-primary" type="submit">Update</button>
        </form>
            <div class="progress" v-else-if="loading">
                <div class="indeterminate"></div>
            </div>
 </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Contact from '../models/Contact'
import ContactService from '../../src/ContactService'
var contactService = new ContactService()
export default Vue.extend({
  name: 'basicUpdate',
  props: {
    contact: Object
  },
  data () {
    return {
      loading: false,
      Id: null,
      name: '',
      lastname: '',
      company: '',
      dateOfBirth: '',
      notes: '',
      phones: [],
      emails: [],
      adresses: []
    }
  },
  methods: {
    onUpdate () {
    // @ts-ignore
      var contact = new Contact(this.Id, this.name, this.lastname, this.company, this.dateOfBirth, this.notes, this.phones, this.emails, this.adresses)
      contactService.updateContact(contact)
    }
  },
  watch: {
    contact (contact) {
      this.Id = contact.id
      this.name = contact.name
      this.lastname = contact.lastName
      this.company = contact.company
      this.dateOfBirth = contact.dateOfBirth
      this.notes = contact.notes
    }
  }
})
</script>
<style lang="scss" >
.modal-content[data-v-fae5bece] {
    width: 160%!important;
}
.btn{
  font-size: 10px;
  display:block;
  margin-top:10px;
  width:100px;
  text-align: center;
  padding:0px;
  height: 20px;
  line-height: 20px;
}
.form-wrapper{
    margin-top:0px!important;
    padding:0px!important;
}
</style>
