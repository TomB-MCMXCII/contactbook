<template>
     <div class="google-map" :id="mapName"></div>
</template>

<script lang="ts">
import Vue from 'vue'
import Contact from '../models/Contact'
import adresses from '../models/ContactAdress'
export default Vue.extend({
  name: 'google-map',
  props: {
    contact: Object,
    name: String
  },
  data () {
    return {
      mapName: this.name + '-map',
      adresses: [{
        lat: 0,
        lng: 0
      },
      {
        lat: 0,
        lng: 0
      },
      {
        lat: 0,
        lng: 0
      }
      ],
      map: null,
      bounds: null,
      markers: []
    }
  },
  watch: {
    contact (contact) {
      this.adresses = contact.adresses
      this.bounds = new google.maps.LatLngBounds()
      const element = document.getElementById(this.mapName)
      const mapCentre = this.adresses[0]
      const options = {
        zoom: 14,
        center: new google.maps.LatLng(mapCentre.lat, mapCentre.lng)
      }
      this.map = new google.maps.Map(element, options)
      var adresses = this.adresses.filter(adress => adress.lat !== 0 && adress.lng !== 0)
      adresses.forEach((coord) => {
        const position = new google.maps.LatLng(coord.lat, coord.lng)
        const marker = new google.maps.Marker({
          position,
          map: this.map
        })
        // this.markers.push(marker)
        this.map.fitBounds(this.bounds.extend(position))
      })
    }
  }
})
</script>

<style lang="scss" scoped>
.google-map {
  width: 100%;
  height: 400px;
  margin: 0 auto;
  background: gray;
  float:right;
}
</style>
