<script setup>
    import { ref, computed } from 'vue'
    /*  import { useStore } from 'vuex'*/
    import axios from 'axios'



    const log = console.log

    const submitBook = () => {
        log('Book submitted')
    }
</script>




<template>
    <h1>Form goes here</h1>
    <form @submit.prevent="submitBook" action="/" method="post">
        <button class="btn btn-primary">Add Book</button>
    </form>
</template>






