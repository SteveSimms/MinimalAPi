<script setup>
    import { ref } from 'vue'
    import { reactive } from 'vue'
    import axios from 'axios'

    import SearchBook from './SearchBook.vue'

    defineProps({
        msg: String
    })

    const count = ref(0)

    let state = reactive({
        message: 'empty',
        book: []
    })

    let books = ref([])

    let testAPI = fetch('http://localhost:5106/test') // returning 404
        .then((res) => {
            console.log('From Book.vue',res)
            return res.text()
        })
        .then(t => state.message = t)

   let getBooks =  axios.get('http://localhost:5106/api/books')
       .then((resposne) => {
            console.log('From Book.vue', resposne.data)
            books.value = resposne.data
           return resposne.data
        })
    /*   .then(b => book.value = b)*/

    /* console.log(get)*/
</script>

<template>
    <h1>{{ msg }}</h1>
    <h1>{{ state.message }}</h1>

    <SearchBook />
    <ul>
        <li v-for="book in books"> {{ book.title }} By {{ book.author }} <br />{{ book.description }}  </li>
    </ul>




</template>

<style scoped>
    a {
        color: #42b983;
    }
</style>
