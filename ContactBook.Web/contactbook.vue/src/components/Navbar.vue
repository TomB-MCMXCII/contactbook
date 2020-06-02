<template>
    <nav>
      <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <a class="navbar-brand" href="#">Contact Book</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarSupportedContent">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item">
        <a class="nav-link"><router-link to="/">Home</router-link></a>
      </li>
      <li class="nav-item">
        <a class="nav-link"><router-link to="/about">About</router-link></a>
      </li>
      <!-- <li class="nav-item">
        <a class="nav-link"><router-link to="/about">Contacts</router-link></a>
      </li> -->
    </ul>
    <form class="form-inline my-2 my-lg-0 flex">
      <span><input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search"
      v-model="searchText"
      @keyup.enter="submit"></span>
        <div class="dropdown">
            <select class="custom-select" id="inputGroupSelect01"
            v-model="selected">
                <option>Search by</option>
                <option value="1">Name</option>
                <option value="2">Last name</option>
                <option value="3">Company</option>
                <option value="4">Phone</option>
                <option value="5">Email</option>
            </select>
        </div>
    </form>
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
      Add contact
    </button>
      <!-- Add contact modal -->
      <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-body">
              <AddForm/>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal" @click="closed()" ref="myBtn"  >Close</button>
              <!-- <button type="button" class="btn btn-primary">Save changes</button> -->
            </div>
          </div>
        </div>
      </div>
  </div>
</nav>
  </nav>
</template>
<script lang="ts">
import Vue from 'vue'
import 'bootstrap/dist/css/bootstrap.min.css'
import AddForm from '../components/AddForm.vue'
import home from '../views/Home.vue'
import Contact from '../models/Contact'
import ContactService from '../ContactService'
var contactServices = new ContactService()
export default Vue.extend({
  name: 'Navbar',
  components: {
    AddForm
  },
  data () {
    return {
      searchText: '',
      selected: 'Search by'
    }
  },
  methods: {
    submit () {
      this.$emit('inputData', this.searchText, this.selected)
      this.searchText = ''
    },
    closed () {
      this.$emit('clickFromChildComponent')
    }
  }
})
</script>
<style lang="scss" scoped>

.navbar-nav a{
    color: beige !important;
    font-size: 130% !important;
    }
.navbar {
  height:120%;
}
// .btn{
//   height:2.5em;
//   font-size: 1.2em!important;
//   margin-left:2em;
// }
input{
  background-color: beige!important;
  height:1.5em!important;
  margin:1em 2em 1em 5.5em!important;
  font-size: 1.4em!important;

}
.modal {
  max-height: 90%;
}
.modal-backdrop {
    z-index: 900;
}
.modal-content[data-v-41458b80] {
    width: 160%;
    height: 100%;
}
.modal-dialog{
  margin:10px;
  height:95%;
}
.custom-select{
  margin-right:400px;
}
span{
  display: inline-flex;
  padding-top:5px;
}
.form-control.mr-sm-2{
  margin-right:5px!important;
}
</style>
