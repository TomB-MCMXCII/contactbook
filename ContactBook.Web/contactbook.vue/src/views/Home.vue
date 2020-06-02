<template>
  <div class="home">
    <Navbar @inputData="updateContacts" @clickFromChildComponent="handleClickInParent"/>
    <div class="container-fluid">
      <div class="row" v-for="contact in contacts"
      v-bind:item="contact"
      :key="contact.id">
        <div class="card bg-white" style="width: 18rem;">
          <div class="card-body ">
              <div class="row">
                <div class="col-md-1 avatar">
                    <img src="../images/img_avatar3.png" alt="Smiley face" height="96" width="85">
                    <a href="#" class="btn btn-primary" data-toggle="modal" data-target="#mapModal" @click="editContact(contact)">Show on map</a>
                    <span><a href="#" class="btn btn-primary " data-toggle="modal" data-target="#editPhonesModal" @click="editContact(contact)">Edit phones</a></span>
                    <span><a href="#" class="btn btn-primary " data-toggle="modal" data-target="#editEmailsModal" @click="editContact(contact)">Edit emails</a></span>
                    <a href="#" class="btn btn-primary " data-toggle="modal" data-target="#editModal" @click="editContact(contact)">Edit contact</a>
                     <a href="#" class="btn btn-primary " data-toggle="modal" data-target="#editAdressesModal" @click="editContact(contact)">Edit adresses</a>
                    <a href="#" class="btn btn-primary btn-deleteContact" @click="deleteContact(contact.id)">Delete contact</a>
                </div>
                  <div class="col-md-3 col nameLastName">
                    <p>{{contact.name}} {{contact.lastName}}</p>
                    <div class="company">
                      <p>Works at: {{contact.company}}</p>
                      <p>Birthday: {{contact.dateOfBirth}}</p>
                      <p class="notes">Notes: {{contact.notes}}</p>
                  </div>
                  </div>
                  <div class="col-md-2 phones">
                    <p>Phones</p>
                    <div class="contact-phones contact-info" v-for="phone in contact.phones"
                        v-bind:item="phones"
                        :key="phone.id">
                        <i class="tiny material-icons">phone</i><span>{{phone.phoneNumber}}</span>
                        <span class="type" v-if="phone.type == 0 && phone.phoneNumber != ''"> Home</span>
                        <span class="type" v-if="phone.type == 1 && phone.phoneNumber != ''"> Work</span>
                        <span class="type" v-if="phone.type == 2 && phone.phoneNumber != ''"> Mobile</span>
                    </div>
                    <div v-if="contact.phones.length == 0">
                      <div class="contact-info"><i class="tiny material-icons">phone</i><span>Empty</span></div>
                      <div class="contact-info"><i class="tiny material-icons">phone</i><span>Empty</span></div>
                      <div class="contact-info"><i class="tiny material-icons">phone</i><span>Empty</span></div>
                    </div>
                    <!-- <span><a href="#" class="btn btn-primary " data-toggle="modal" data-target="#editPhonesModal" @click="editContact(contact)">Edit phones</a></span> -->
                  </div>
                  <div class="col-md-3 emails">
                    <p>Emails</p>
                    <div class="contact-emails contact-info" v-for="a in contact.emails"
                        v-bind:item="b"
                        :key="a.id">
                        <i class="tiny material-icons">mail</i><span>{{a.email}}</span>
                        <span class="type" v-if="a.type == 0  && a.email != ''"> Personal</span>
                        <span class="type" v-if="a.type == 1  && a.email != ''"> Work</span>
                    </div>
                    <div v-if="contact.emails.length == 0">
                      <div class="contact-info"><i class="tiny material-icons">mail</i><span>Empty</span></div>
                      <div class="contact-info"><i class="tiny material-icons">mail</i><span>Empty</span></div>
                      <div class="contact-info"><i class="tiny material-icons">mail</i><span>Empty</span></div>
                    </div>
                   <!-- <span><a href="#" class="btn btn-primary " data-toggle="modal" data-target="#editEmailsModal" @click="editContact(contact)">Edit emails</a></span> -->
                  </div>
                  <div class="col-md-3 addresses">
                    <p>Adresses</p>
                    <div class="contact-emails contact-info" v-for="adress in contact.adresses"
                        v-bind:item="b"
                        :key="adress.id">
                        <i class="tiny material-icons">home</i><span>{{adress.street}} {{adress.houseNumber}} {{adress.city}}</span>
                    </div>
                    <div v-if="contact.adresses.length == 0">
                      <div class="contact-info"><i class="tiny material-icons">home</i><span>Empty</span></div>
                      <div class="contact-info"><i class="tiny material-icons">home</i><span>Empty</span></div>
                      <div class="contact-info"><i class="tiny material-icons">home</i><span>Empty</span></div>
                    </div>
                    <!-- <span><a href="#" class="btn btn-primary " data-toggle="modal" data-target="#editModal" @click="editContact(contact)">Edit Adresses</a></span> -->
                  </div>
                  </div>
                     <div class="row">
                      <div class="col-md-1 buttons">
                    </div>
                  </div>
                  </div>
        </div>
      </div>
                      <!-- Modal -->
                      <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                          <div class="modal-content">
                            <div class="modal-body">
                              <!-- Basic Update Form -->
                              <basicUpdate :contact="contact"/>
                            </div>
                            <div class="modal-footer">
                              <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                          </div>
                        </div>
                      </div>
                      <div class="modal fade" id="mapModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                          <div class="modal-content">
                            <div class="modal-body">
                              <!-- Contact map -->
                              <ContactMap name="example" :contact="contact"></ContactMap>
                            </div>
                            <div class="modal-footer">
                              <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                          </div>
                        </div>
                      </div>
                      <div class="modal fade" id="editPhonesModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                          <div class="modal-content phone-update-modal">
                            <div class="modal-body">
                              <!-- Phone Update Form -->
                              <updatePhones :contact="contact"/>
                            </div>
                            <div class="modal-footer">
                              <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                          </div>
                        </div>
                      </div>
                      <div class="modal fade" id="editEmailsModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                          <div class="modal-content phone-update-modal">
                            <div class="modal-body">
                              <!-- Emails Update Form -->
                              <updateEmails :contact="contact"/>
                            </div>
                            <div class="modal-footer">
                              <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                          </div>
                        </div>
                      </div>
                       <div class="modal fade" id="editAdressesModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                          <div class="modal-content phone-update-modal">
                            <div class="modal-body">
                              <!-- Adress Update Form -->
                              <updateAdresses :contact="contact"/>
                            </div>
                            <div class="modal-footer">
                              <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                          </div>
                        </div>
                      </div>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
// @ts-ignore
import Navbar from '../components/Navbar'
import '../../node_modules/materialize-css/dist/css/materialize.min.css'
import AddForm from '../../src/components/AddForm'
import ContactService from '../ContactService'
import Contact from '../models/Contact'
import basicUpdate from '../components/BasicUpdateContact'
import updatePhones from '../components/UpdatePhones'
import updateEmails from '../components/UpdateEmails'
import updateAdresses from '../components/UpdateAdresses'
import ContactMap from '../components/ContactMap'
const contactService = new ContactService()
let contact = new Contact()

export default {
  name: 'home',
  components: {
    Navbar,
    basicUpdate,
    updatePhones,
    updateEmails,
    updateAdresses,
    ContactMap
  },
  data () {
    return {
      contacts: [],
      contact: Contact,
      selected: '',
      searchText: ''
    }
  },
  methods: {
    deleteContact (id) {
      contactService.deleteContact(id)
        .then(() => {
          contactService.getAllContacts()
            .then(res => {
              this.contacts = res.data
            })
        })
    },
    handleClickInParent () {
      contactService.getAllContacts()
        .then(res => {
          this.contacts = res.data
          console.log(this.contacts)
        })
    },
    editContact (contact) {
      this.contact = contact
    },
    updateContacts (searchText, selected) {
      this.contacts.length = 0
      this.searchText = searchText
      this.selected = selected
      if (this.selected === '0') {
        contactService.getAllContacts()
          .then(res => {
            this.contacts = res.data
            console.log(this.contacts)
          })
      }
      if (this.selected === '1') {
        contactService.searchByName(searchText)
          .then(res => {
            this.contacts = res.data
            console.log(this.contacts)
          })
      }
      if (this.selected === '2') {
        contactService.searchByLastname(searchText)
          .then(res => {
            this.contacts = res.data
            console.log(this.contacts)
          })
      }
      if (this.selected === '3') {
        contactService.searchByCompany(searchText)
          .then(res => {
            this.contacts = res.data
            console.log(this.contacts)
          })
      }
      if (this.selected === '4') {
        contactService.searchByPhone(searchText)
          .then(res => {
            this.contacts.push(res.data)
            console.log(this.contacts)
          })
      }
      if (this.selected === '5') {
        contactService.searchByEmail(searchText)
          .then(res => {
            this.contacts.push(res.data)
            console.log(this.contacts)
          })
      }
    }
  },
  created () {
    contactService.getAllContacts()
      .then(res => {
        this.contacts = res.data
        console.log(this.contacts)
      })
  }
}
</script>
<style lang="scss" scoped>
.container-fluid{
  margin-top:50px;
  padding: 2em;
  text-align: center;
  width:80%;
}
.card{
  width:100%!important;
}
.card-body{
  padding:5px;
}
.notes{
    margin-bottom:0px!important;
  }
.row{
  margin-bottom:10px!important;
}
.contact-name{
  font-size: 45px;
}
.contact-buttons{
  position: relative;
}
.avatar{
  text-align: left;
  padding-left:5px;
}
.company{
  text-align: left;
  font-size: 15px;
}
.buttons{
  text-align: right;
}
.phones, .emails, .addresses{
  text-align: left;
  font-size: 20px;
}
.nameLastName {
  text-align: left;
  font-size: 40px;;
}
.modal-content {
    width: 250%;
}
.modal-dialog{
  margin:10px;
}
.btn-deleteContact{
  background-color: red;
}
.contact-info{
  font-size:15px;
  line-height: 30px;
  margin-top:10px;
}
// .btn{
//   float:right;
//   margin-top:10px;
//   margin-right:40px;
//   width:150px;
// }
.card-body{
  padding-bottom:0px!important;
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
.container-fluid{
  width:100%;
}
.col{
//  border-width: 1px; /* this allows you to adjust the thickness */
// border-style: solid;
}
img{
  position: relative;
  display: block;
}
i{
  margin-right: 10px;
  font-size: 1.4em;
  position: relative;
  top: 5px;
}
span{
  font-weight: 500;
}
.type{
  font-weight: 100;
}
.phones, .emails, .addresses {
  p{
    font-size: 25px;
    margin-bottom: 35px;
  }
}
</style>
