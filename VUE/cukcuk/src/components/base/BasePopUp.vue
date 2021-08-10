<template>
  <div :class="{'hide-popup':hide}">
      <div :class="['popup',subClass]">
      <div>
      <b>{{popupTitle}}</b>
      </div>
      <button class="btn-x" @click="$emit('btnPopupCancelOnClick')"></button>
      <div class="popupContent">
          <div :class="['img-warning',subClass]"></div>
          <div class="popupText"><p>{{popupContent}}</p></div>
      </div>
      <div class="popupPaging">
          <button class="buttonCancel" @click="$emit('btnPopupCancelOnClick')">Hủy</button>
            <button class="button-popup" @click="$emit('btnPopupOnClick')" >
            {{btnText}}
            </button>
      </div>
      </div>
  </div>
</template>

<script>
// import Button from '../base/BaseButton.vue'
export default {
name:'Popup',
component:{},
props:{
subClass:String,
popupTitle:String,
btnText:String,
popupContent:{},
hide:{
        type:Boolean,
        default:true,
        required:true,
    },
},
}
</script>

<style>

.hide-popup{
    visibility: hidden;
}
.popup{
    display: block;
    z-index: 10;
    width: 400px;
    height: 194px;
    background-color: #fff;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    border-radius: 4px;
    box-shadow: rgba(255, 255, 255, 0.1) 0px 1px 1px 0px inset, rgba(50, 50, 93, 0.25) 0px 50px 100px -20px, rgba(0, 0, 0, 0.3) 0px 30px 60px -30px;
}
.btn-x{
background-color:#ffffff;
background-image: url(../../assets/icon/x.svg);
background-position: center;
background-repeat: no-repeat;
height: 25px;
width: 25px;
position: absolute;
right: 0px;
top: 0px;
border: none;
cursor: pointer;
}
.btn-x:hover{
    background-color: #bbbbbb;
    border-radius: 4px;
}
.popup b{
    
    position: absolute;
    top: 24px;
    left: 24px;
    margin-right: 24px;
    margin-bottom: 24px;  
}
.popupContent{
    height: 50px;
    width: 100%;
    position: absolute;
    top: 64.67px;
}
.img-warning{
    border-radius: 50%;
    height: 40px;
    width: 40px;
    position: absolute;  
    left: 24px;
}
.message .img-warning{
    background-image: url(../../assets/icon/message.png);
    background-position: center;
    background-size: contain;
}
.danger .img-warning{
    background-image: url(../../assets/icon/danger.png);
    background-position: center;
    background-size: contain;
}
.popupText{
    position: absolute;
    left: 74px;
    margin: 0px;
    display: inline-block;
    width: 302px;
    
}
.popupText p{
    margin-top: 0px ;
    word-wrap: break-word;
}
.popupPaging{
    position: absolute;
    bottom: 0px;
    background-color: #E9EBEE  ;
    height: 60px;
    width: 100%;
    display: flex;
    
}
.button-popup{
    position: absolute;
    right: 24px;
    margin-top: 10px;
    padding-left:33px;
    border-radius: 4px;
    height: 40px;
    text-align:center;
    cursor: pointer;
    border:none;
    color: #ffffff;
    display: flex;
    align-items: center;
    min-width: 100px;
}
.message .button-popup{
    background-color: #019160;
}
.message .button-popup:hover{
background-color: #2FBE8E;

}

.message .button-popup:active{
    background-color: #01B075;
}
.danger .button-popup{
    background-color: #F65454;
}
.danger .button-popup:hover{
background-color: #FFCECE ;

}

.danger .button-popup:active{
    background-color: #FF4747
;
} 
.buttonCancel{
    position: absolute;
    right: 140px;
    margin-top: 10px;
    background-color: #E9EBEE;
    border-radius: 4px;
    height: 40px;
    text-align:center;
    padding-left:33px;
    cursor: pointer;
    border:none;
    color: #000;
    display: flex;
    align-items: center;
    min-width: 100px;
}
.buttonCancel:hover{
    background-color: #bbbbbb;
}
</style>