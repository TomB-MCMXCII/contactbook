<template>
    <div class="container-fluid">
  <form v-if="!loading" class="form" v-on:submit="onUpdate">
  <div class="form-row" v-for="phone in phones"
      v-bind:item="phone"
      :key="phone.id">
    <div class="col-md-2 mb-1">
      <!-- <label for="validationServer03">Phone number</label> -->
      <input type="text-field" class="form-control" id="validationServer01" pattern="\d+" minlength="8" maxlength="8" placeholder="Phone number"
      v-model="phone.phoneNumber">
    </div>
          <div class="col-md-2 mb-4">
            <!-- <label for="exampleFormControlSelect1">Type</label> -->
            <select class="form-control type" id="exampleFormControlSelect1"
            v-model="phone.type">
              <option value="0">Home</option>
              <option value="1">Work</option>
              <option value="2">Mobile</option>
            </select>
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
var contactServices = new ContactServices()
export default Vue.extend({
  name: 'updatePhones',
  data () {
    return {
      phones: [],
      loading: false
    }
  },
  props: {
    contact: Object
  },
  methods: {
    onUpdate () {
      this.loading = true
      contactServices.updatePhone(this.phones[0])
        .then(res => {
          console.log(res.data)
        })
        .catch(err => console.error(err))
      contactServices.updatePhone(this.phones[1])
        .then(res => {
          console.log(res.data)
        })
        .catch(err => console.error(err))
      contactServices.updatePhone(this.phones[2])
        .then(res => {
          console.log(res.data)
        })
        .catch(err => console.error(err))
      this.loading = false
    }
  },
  watch: {
    contact (contact) {
      this.phones = contact.phones
    }
  }
})
</script>
<style lang="scss" scoped>
input:invalid {
  border: 2px dashed red;
}
</style>
