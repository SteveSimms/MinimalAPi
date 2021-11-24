<script setup>
    import { ref, computed } from 'vue'
    /*  import { useStore } from 'vuex'*/
    import axios from 'axios'

    //const props = defineProps({
    //    books:
    //})
    const books = ref([])

    //Ship THIS Object to the server
    let formInputs = ref({
        title: '',
        author: '',
        description: '',
        imageFile: null
    })

    const log = console.log

    const submitBook = async () => {
        await axios.post('http://localhost:5106/api/books',formInputs.value)
            .then((resposne) => {
                formInputs.value = resposne.data
                console.log('From AddBook.vue', resposne.data)
                return resposne.data
            })
        formInputs.value.title
        formInputs.value.author
        formInputs.value.description
        formInputs.value.imageFile
        log('Book submitted', formInputs.value) //Send formInputs.value to the server
    }
</script>




<template>
    <div class="container">

        <form @submit.prevent="submitBook" action="/" method="post">
            <div class="form-group">
                <label class="control-label">Title</label>
                <input v-model="formInputs.title" class="form-control" />
                <span class="text-danger"></span>
            </div>
            {{ formInputs.title }}
            <div class="form-group">
                <label class="control-label">Author</label>
                <input v-model="formInputs.author" class="form-control" />
                <span class="text-danger"></span>
            </div>
            {{ formInputs.author }}
            <div class="form-group">
                <label class="control-label">Description</label>
                <textarea v-model="formInputs.description" class="form-control"> </textarea>
                <span class="text-danger"></span>
            </div>
            {{ formInputs.description }}

            <div class="form-group">
                <label  class="control-label">Image</label>
                <input @:change="submitBook" type="file"  class="form-control" />
                <span  class="text-danger"></span>
            </div>

            <button class="btn btn-primary">Add Book</button>
        </form>


    </div>






</template>



<style>
    /*    input {
        position: center;
        width: 50%;
    }*/
</style>


