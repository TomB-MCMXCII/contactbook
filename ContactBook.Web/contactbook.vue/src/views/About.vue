<template>
  <div class="about">
    <Navbar/>
    <h1>This is an about page</h1>
    <h2>Currently in development</h2>
  </div>
</template>

<script>
import Navbar from '../components/Navbar'
import '../../node_modules/materialize-css/dist/css/materialize.min.css'

export default {
  name: 'home',
  components: {
    Navbar
  }
}
</script>
