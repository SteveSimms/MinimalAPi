<script setup>
    import {  ref } from 'vue'
    import Book from './Book.vue'

    const props = defineProps({
        books: {
            type: Array,
            default: []
        } 
    })
    console.log('From SearchBook.vue',props.books)
  /*  state.books*/
   

</script>

<template>
    <!--<h1> {{ books }}  </h1>--> 

    <!--<input type="text" value="Search Books"/>-->


</template>