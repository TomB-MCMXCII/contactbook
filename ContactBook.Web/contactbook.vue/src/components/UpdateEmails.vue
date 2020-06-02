<template>
    <div class="container-fluid">
  <form  class="form" v-on:submit="onUpdate" v-if="!loading">
  <div class="form-row" v-for="email in emails"
      v-bind:item="email"
      :key="email.id">
    <div class="col-md-6 mb-1">
      <!-- <label for="validationServer03">Phone number</label> -->
      <input type="text-field" class="form-control" placeholder="Email" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$"
      v-model="email.email">
    </div>
          <div class="col-md-2 mb-4">
            <!-- <label for="exampleFormControlSelect1">Type</label> -->
            <select class="form-control type" id="exampleFormControlSelect1"
            v-model="email.type">
              <option value="0">Personal</option>
              <option value="1">Work</option>
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
  name: 'updateEmails',
  data () {
    return {
      emails: [],
      loading: false
    }
  },
  props: {
    contact: Object
  },
  methods: {
    onUpdate () {
      contactServices.updateEmail(this.emails[0])
        .then(res => {
          console.log(res.data)
        })
        .catch(err => console.error(err))
      contactServices.updateEmail(this.emails[1])
        .then(res => {
          console.log(res.data)
        })
        .catch(err => console.error(err))
      contactServices.updateEmail(this.emails[2])
        .then(res => {
          console.log(res.data)
        })
        .catch(err => console.error(err))
    }
  },
  watch: {
    contact (contact) {
      this.emails = contact.emails
    }
  }
})
</script>
<style lang="scss" scoped>
input:invalid {
  border: 2px dashed red;
}
</style>
