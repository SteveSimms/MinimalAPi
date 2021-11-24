<script setup>
    import { ref, computed } from 'vue'
    import { reactive } from 'vue'
    import axios from 'axios'

    /* import SearchBook from './SearchBook.vue'*/

    defineProps({
        msg: String
    })

    const count = ref(0)

    let state = reactive({
        message: 'empty'

    })

    let books = ref([])
    let searchInput = ref('')

    let testAPI = fetch('http://localhost:5106/test') // returning 404
        .then((res) => {
            /*  console.log('From Book.vue', res)*/
            return res.text()
        })
        .then(t => state.message = t)

    let getBooks = async () => {
        await axios.get('http://localhost:5106/api/books')
            .then((resposne) => {
                books.value = resposne.data
                console.log('From Book.vue', resposne.data)
                return resposne.data
            })
    }
    getBooks()

    let searchBooks = () => {
        searchInput.value
        console.log(searchInput.value)
        searchInput.value = ''
    }

    let filterBooks =  computed(  () => {
        console.log('From filterBooks', books.value)
         return  books.value.filter((book) => {
            let filteredBooks = book.title.toLowerCase()
                .includes(searchInput.value.toLowerCase())

            return filteredBooks
        })
    })
    /*   .then(b => book.value = b)*/

    /* console.log(get)*/
</script>

<template>
    <h1>{{ msg }}</h1>
    <h1>{{ state.message }}</h1>

    <form @submit.prevent="searchBooks" action="/" method="post">
        <label>Search for Books </label>
        <input v-model="searchInput" type="text" />

    </form>

    <ul>
        <li v-for="book in filterBooks"> {{ book.title }} By {{ book.author }} <br />{{ book.description }} <br /> {{ book.imageName }}  </li>
    </ul>




</template>

<style scoped>
    a {
        color: #42b983;
    }
    li {
        list-style-type: none;
    }
</style>
