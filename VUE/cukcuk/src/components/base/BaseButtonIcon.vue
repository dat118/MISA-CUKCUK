<template>
  <div>
      <button :class="['button-icon',shape,color]" :id="idButton">
          <div class="button-logo"><div :class="iconChoose"></div></div>
          <div class="button-value">{{buttonText}}</div>
      </button>
  </div>
</template>

<script>
export default {
name:'ButtonIcon',
props:{
    shape:String,
    idButton:String,
    iconChoose:String,
    buttonText:String,
    color:String,
}
}
</script>

<style>
.button-icon{
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
.button-icon:hover{
background-color: #2FBE8E;

}

.button-icon:active{
    background-color: #01B075;

}


</style>