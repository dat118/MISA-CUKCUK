<template>
  <div>
    <button
      :class="['button-icon', subClass, shape, color]"
      :id="idButton"
      @click="$emit('btnClick')"
    >
      <div class="button-logo"><div :class="iconChoose"></div></div>
      <div class="button-value">{{ buttonText }}</div>
    </button>
  </div>
</template>

<script>
export default {
  name: "ButtonIcon",
  props: {
    shape: String,
    idButton: String,
    iconChoose: String,
    buttonText: String,
    color: String,
    subClass:Object
  },
};
</script>

<style>
.button-icon {
  background-color: #019160;
  border-radius: 4px;
  height: 40px;
  text-align: center;
  padding-left: 16px;
  padding-right: 16px;
  cursor: pointer;
  border: none;
  color: #ffffff;
  display: flex;
  align-items: center;
}
.button-icon:hover {
  background-color: #2fbe8e;
}

.button-icon:active {
  background-color: #01b075;
}
.circle {
  border-radius: 50%;
  border: 1px solid #bbb;
}
.rectangle {
  width: 40px;
  border: none;
  padding-left: 12px;
}

.white {
  background-color: #e9ebee;
  color: #000;
  font-weight: bold;
}

.white:active {
  background-color: #2fbe8e;
  color: #fff;
}

.white:hover {
  background-color: #fff;
  color: #000;
}
</style>