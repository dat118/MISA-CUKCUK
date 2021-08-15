<template>
  <div :class="{'hide-toast':toastHide}">
    <div :class="['toastMess',subClass]" >
      <div :class="['img-toast',subClass]"></div>
      <div class="toastText"><p>{{toastContent}}</p></div>
      <button :class="['btn-cancel',subClass]" @click="$emit('toastMessHide')"></button>
    </div>
  </div>
</template>

<script>

export default {
  name:'ToastMessager',
  props:{
    subClass:String,
    toastContent:String,
    toastHide:{
        type:Boolean,
        default:true,
        required:true,
    },
  },
 
}
</script>

<style>
.hide-toast{
    visibility: hidden;
}
.toastMess{
  z-index: 11;
  height: 48px;
  width: 220px;
  box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
  /* box-shadow: rgba(255, 255, 255, 0.1) 0px 1px 1px 0px inset, rgba(50, 50, 93, 0.25) 0px 50px 100px -20px, rgba(0, 0, 0, 0.3) 0px 30px 60px -30px; */
  border-radius: 4px;
  color: black;
  position: absolute;
  top: 30px;
  left: 50%;
  transform: translate(-50%, -50%);
  /* position: relative; */
  background-color: #fff;
}
.img-toast{
  border-radius: 50%;
  height: 24px;
  width: 24px;
  position: absolute;
  margin:12px ;
}
.danger .img-toast {
    background-image: url(../../assets/icon/danger.png);
    background-position: center;
    background-size: contain;
}
.message .img-toast{
    background-image: url(../../assets/icon/greencheck.png);
    background-position: center;
    background-size: contain;
}
.toastText{
  position: absolute;
  top: 0px;
  left: 48px;
  
}
.btn-cancel{
  height: 48px;
  width: 48px;
  padding: 0px;
  border: none;
  border-radius: 4px ;
  position: absolute;
  top: 0px;
  right: 0px;
  cursor: pointer;
  background-color: #fff;
}
.btn-cancel:hover{
background-color: #E9EBEE;
}
.danger .btn-cancel{
    background-image: url(../../assets/icon/x-red.png);
    background-position: center;
    background-size: 40%;  
    background-repeat: no-repeat;
}
.message .btn-cancel{
  background-image: url(../../assets/icon/x-green.png);
    background-position: center;
    background-size: 40%;  
    background-repeat: no-repeat;
}

</style>