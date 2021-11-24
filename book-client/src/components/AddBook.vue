<script setup>
    import { ref, watch } from 'vue'
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
        imageName: '',
        imageFile: '',
        imageUrl: ''
    })
    let imageFile = ref('')
    let imageUrl = ref('')

    const log = console.log

    const submitBook = async (event) => {
        await axios.post('http://localhost:5106/api/books', formInputs.value)
            .then((resposne) => {
                formInputs.value = resposne.data
                console.log('From AddBook.vue', resposne.data)
                return resposne.data
            })
        formInputs.value.title
        formInputs.value.author
        formInputs.value.description
        formInputs.value.imageName,
            formInputs.value.imageFile

        log('Book submitted', formInputs.value) //Send formInputs.value to the server
    }

    const handleImageSelected = (event) => {
        log(event)

        if (event.target.files === 0) {
            return
        }
        //Storing the event.target(ed) file in the imageFile reactive variable
        imageFile.value = event.target.files[0]
    }

    watch(imageFile, (imageFile) => {
        let fileReader = new FileReader()
        fileReader.readAsDataURL(imageFile)

        fileReader.addEventListener('load', () => {
            imageUrl.value = fileReader.result
            log('script setup ->  imageUrl.value', imageUrl.value)
        })
    })

    //const previewImage = () => {
    //    let input = event.target
    //    if (input.files && input.files[0]) {
    //        let reader = new FileReader()
    //        reader.onload = (e) => {
    //            this.imageData = e.target.result
    //        }
    //        reader.readAsDataURL(input.files[0])
    //    }

    //}
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

            <div class="form-group">
                <label class="control-label">Image</label>
                <input @change="handleImageSelected" type="file" class="form-control" />
                <span class="text-danger"></span>
            </div>

            {{ formInputs.imageName }}
            <!--Upload an image file:
            <input type="file" @change="previewImage" accept="image/*">-->
            <!--<div class="image-preview" v-if="imageData.length > 0">
                <img class="preview" :src="imageData">
            </div>-->

            <button class="btn btn-primary">Add Book</button>
        </form>


    </div>






</template>



<style>
    .file-upload-form, .image-preview {
        font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
        padding: 20px;
    }

    img.preview {
        width: 200px;
        background-color: white;
        border: 1px solid #DDD;
        padding: 5px;
    }
</style>


