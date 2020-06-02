<template>
<div class="container-fluid">
  <form  class="form" v-on:submit="onUpdate" v-if="!loading">
  <div class="form-row">
    <div class="col-md-4 mb-1" v-for="adress in adresses"
      v-bind:item="adress"
      :key="adress.id">
      <!-- <label for="validationServer03">Phone number</label> -->
      <input type="text-field" class="form-control" id="validationServer01" placeholder="Street"
      v-model="adress.street">
      <input type="text-field" class="form-control" id="validationServer01" placeholder="House number" pattern="\d+" minlength="1" maxlength="4"
      v-model="adress.houseNumber">
      <input type="text-field" class="form-control" id="validationServer01" placeholder="City"
      v-model="adress.city">
          <div class="col-md-8 mb-4">
            <!-- <label for="exampleFormControlSelect1">Type</label> -->
            <select class="form-control type" id="exampleFormControlSelect1"
            v-model="adress.type">
              <option value="0">Home</option>
              <option value="1">Work</option>
            </select>
          </div>
          </div>
  </div>
  <button class="btn btn-primary" type="submit">Update</button>
  </form>
  <div class="progress" v-if="loading">
      <div class="indeterminate">
      </div>
  </div>
</div>
</template>
<script lang="ts">
import Vue from 'vue'
import Contact from '../models/Contact'
import ContactPhone from '../models/ContactPhone'
import ContactServices from '../ContactService'
import AdressValidationServices from '../AdressValidationService'
import ContactAdress from '../models/ContactAdress'
var contactServices = new ContactServices()
var adressServices = new AdressValidationServices()
export default Vue.extend({
  name: 'updateAdresses',
  data () {
    return {
      adresses: [],
      loading: false
    }
  },
  props: {
    contact: Object
  },
  methods: {
    onUpdate () {
      var adresses:ContactAdress[] = []
      adresses = this.adresses
      contactServices.updateAdress(this.adresses[0])
        .then(res => {
          var adress1Status = res.status
          console.log(res.data)
        })
        .catch(err => console.error(err))
      contactServices.updateAdress(this.adresses[1])
        .then(res => {
          console.log(res.data)
        })
        .catch(err => console.error(err))
      contactServices.updateAdress(this.adresses[2])
        .then(res => {
          console.log(res.data)
        })
        .catch(err => console.error(err))
    }
  },
  watch: {
    contact (contact) {
      this.adresses = contact.adresses
    }
  }
})
</script>
<style lang="scss" scoped>
</style>
