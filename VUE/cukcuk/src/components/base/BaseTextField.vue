<template>
  <div>
    <input
      :id="idTextField"
      class="text-field"
      type="text"
      :placeholder="placeHolder"
      v-model="dataContent"
      @change="onChange($event.target.value)"
    />
  </div>
</template>

<script>
export default {
  name: "TextField",
  props: {
    placeHolder: String,
    idTextField: String,
    textContent: String,
  },
  data() {
    return {
      dataContent: this.textContent,
    };
  },
  created() {
    this.dataContent = this.textContent;
  },
  methods: {
    onChange(value){
        this.$emit('input',value);
    }
  },
  watch: {
    textContent: function () {
      this.dataContent = this.textContent;
    },
  },
};
</script>

<style>
.text-field {
  height: 40px;
  border: 1px solid #bbbbbb;
  border-radius: 4px;
  color: #000000;
  padding-left: 16px;
  width: 200px;
  padding-top: 0px;
  padding-bottom: 0px;
  padding-right: 2px;
}

.text-field:focus {
  outline: none;
  border: 1px solid #019160;
}
.text-field::placeholder {
  font-size: 12px;
  color: #bbbbbb;
  text-align: left;
  padding-left: 5px;
}
</style>