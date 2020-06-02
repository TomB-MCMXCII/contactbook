<template>
  <div class="search-wrapper">
    <input type="text" v-model="search" />
        <label>Search by name</label>
        <input type="text" v-model="search" />
        <label>Search by lastname</label>
        <input type="text" v-model="search" />
        <label>Search by company</label>
        <input type="text" v-model="search" />
        <label>Search by phone</label>
        <input type="text" v-model="search" />
        <label>Search by email</label>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
  name: 'Search'
})
</script>
