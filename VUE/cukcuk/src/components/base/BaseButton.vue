<template>
  <div>
      <button :class="['button',subClass,shape,color]"
      @click="$emit('btnClick')"><p>{{Text}}</p></button>
  </div>
</template>

<script>
export default {
    name:'Button',
    props:{
        Text:String,
        shape:String,
        color:String,
        subClass:{},
    }
}
</script>


<style>
.button{
    background-color: #019160;
    border-radius: 4px;
    height: 40px;
    text-align:center;
    padding-left: 16px;
    padding-right: 16px;
    cursor: pointer;
    border:none;
    color: #ffffff;
    display: flex;
    align-items: center;
}
.button:hover{
background-color: #2FBE8E;

}

.button:active{
    background-color: #01B075;

}

</style>