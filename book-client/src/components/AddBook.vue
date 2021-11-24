<script setup>
    import { ref, reactive, watch } from 'vue'
    /*  import { useStore } from 'vuex'*/
    import axios from 'axios'

    //const props = defineProps({
    //    books:
    //})
    const books = ref([])

    //Ship THIS Object to the server
    let formInputs = reactive
        ({
            title: '',
            author: '',
            description: '',
            imageName: '',
            imageFile: '',
            imageUrl: ''

        })
    let imageFile = ref('')
    let imageUrl = ref('')

    const log = console.log

    const submitBook = async (event) => {
        await axios.post('http://localhost:5106/api/books', formInputs)
            .then((resposne) => {
                formInputs = resposne.data
                console.log('From AddBook.vue', resposne.data)
                return resposne.data
            })
        formInputs.title
        formInputs.author
        formInputs.description
        formInputs.imageName


        log('Book submitted', formInputs) //Send formInputs.value to the server
    }

    const handleImageSelected = (event) => {
        log(event)

        if (event.target.files === 0) {
            imageFile.value = ''
            imageUrl.value = ''
            return
        }
        //Storing the event.target(ed) file in the imageFile reactive variable
        imageFile.value = event.target.files[0]
    }

    watch(imageFile, (imageFile) => {
        if (!(imageFile instanceof File)) {
            return
        }



        let fileReader = new FileReader()

        fileReader.readAsDataURL(imageFile)

        fileReader.addEventListener('load', () => {
            imageUrl.value = fileReader.result
            log('script setup ->  imageUrl.value', imageUrl.value)

        })
    })



</script>




<template>
    <div class="container">

        <form @submit.prevent="submitBook" class="file-upload-form" action="/" method="post">

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
            <img v-show="imageUrl" :src="imageUrl" alt="Some Picture">
            <div class="form-group">
                <label class="control-label">Image</label>
                <input @change="handleImageSelected"
                       type="file"
                       accept="image/*"
                       class="form-control" />
                <span class="text-danger"></span>
            </div>




            <button class="btn btn-primary">Add Book</button>
        </form>


    </div>






</template>



<style>
</style>


