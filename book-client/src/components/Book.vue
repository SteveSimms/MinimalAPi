<script setup>
    import { ref } from 'vue'
    import { reactive } from 'vue'
    import axios from 'axios'

    defineProps({
        msg: String
    })

    const count = ref(0)
    let state = reactive({
        message: 'empty',
        book: []
    })


    fetch('http://localhost:5106/test') // returning 404
        .then((res) => {
            console.log(res.url)
            return res.text()
        })
        .then(t => state.message = t)

    axios.get('http://localhost:5106/api/books')
        .then(res => res.data)
        .then(b => state.book = b)

    /* console.log(get)*/
</script>

<template>
    <h1>{{ msg }}</h1>
    <h1>{{ state.message }}</h1>
    <ul>
        <li v-for="book in state.book"> {{ book.title }} By {{ book.author }} <br/>{{ book.description }}  </li>
    </ul>




</template>

<style scoped>
    a {
        color: #42b983;
    }
</style>
