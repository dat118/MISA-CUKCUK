<template>
  <div>
    <div class="input-zone">
      <label v-if="textLabel">{{ textLabel }}</label>
      <div v-if="invalid" class="tooltip-box">
        <div  class="tooltip">
        {{tooltipWarning}}
        </div>
        <div class="tooltip-arrow"></div>
      </div>
      
      <input
        :id="idTextField"
        class="text-field"
        :class="{money:isMoney,redBorder:invalid,required}"
        :type="type"
        :placeholder="placeHolder"
        v-model="dataContent"
        @input="[onInput($event.target.value),emptyField()]"
        @blur="emailValidation"
        
      />
        
      <div class="currency" v-if="moneyCurrency">({{ moneyCurrency }})</div>
      <div class="clearinput"></div>
    </div>
  </div>
</template>

<script>

export default {
  name: "TextField",
  props: {
    textLabel: String,
    placeHolder: String,
    idTextField: String,
    textContent: {},
    type: String,
    dataType: String,
    moneyCurrency: String,
    isMoney:{
      
      default :false,
    },
    required:String,
    tooltipWarning:String,
  },
  data() {
    return {
      dataContent: this.textContent,
      
      invalid: false,
    };
  },
  created() {
    this.dataContent = this.textContent;
  },
  methods: {
    onInput(value) {
      //Nếu dữ liệu không phải money thì emit lên luôn
      //nếu là money thì định dạng lại rồi mới gửi lên
      let vm = this;
      if (vm.dataType == "money") {
        let isValid = this.toNumberFormat(value),
          displayData = this.toMoneyFormat(value);
        this.$emit("input", isValid);
        this.dataContent = displayData;
      } 
      else if (vm.dataType== "number"){
        let isValid = this.numberOnly(value);
        this.$emit("input", isValid);
        this.dataContent = isValid;
      }
      else {
        this.$emit("input", value);
      }
    },

    toMoneyFormat(myinput) {
      myinput += "";
      if (myinput != null) {
        myinput.replaceAll(".", "");

        let numberString = "";
        for (var i = 0; i < myinput.length; i++) {
          if (!isNaN(parseInt(myinput[i], 10))) {
           numberString += myinput[i];
          }
        }
        return Number (numberString).toLocaleString("vi");
      }
      return 0;
    },
    /**
     * 
     */
    toNumberFormat(myinput) {
      myinput += "";
      if (myinput != null) {
        myinput.replaceAll(".", "");

        let numberString = "";
        for (var i = 0; i < myinput.length; i++) {
          if (!isNaN(parseInt(myinput[i], 10))) {
           numberString += myinput[i];
          }
        }
        return numberString;
      }
      return 0;
    },
    numberOnly(myinput){
       myinput += "";
       if (myinput != null) {
        let numberString = "";
        for (var i = 0; i < myinput.length; i++) {
          if (!isNaN(parseInt(myinput[i], 10))) {
           numberString += myinput[i];
          }
        }
        return numberString;
      }
      return 0;
    },
    emailValidate(myemail){
      //eslint-disable-next-line
      const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (re.test(String(myemail).toLowerCase()) == true) 
            return true;
            else{
              return false;
            }
    },
     emailValidation(){
       let vm =this;
       if(vm.dataType== "email"){
        let isValid = this.emailValidate(vm.dataContent);
        if (isValid == false) {
          this.invalid = true;
          return false;
        } else{
          this.invalid = false;
          return true;
        }
     }
     },
    emptyField(){
      if((this.dataContent == '' || this.dataContent == null)&&this.required=='required'){ 
        this.invalid = true;
        return false;
      }else{  
        this.invalid = false;
        return true;
      }
    },
    inputValidation(){
      switch (this.dataType) {
                
                case 'email':
                    return this.emailValidation(this.dataType);
                case 'number':
                    return this.emptyField(this.dataContent);
                case 'name':
                    return this.emptyField(this.dataContent);
                case 'code':
                    return this.emptyField(this.dataContent);          
    }
  },
  },
  watch: {
    textContent: function () {
      if (this.dataType == "money") {
        let displayData = this.toMoneyFormat(this.textContent);
        this.dataContent = displayData;
      } else {
        this.dataContent = this.textContent;
      } 
    },
  },
};
</script>

<style>
.text-field {
  height: 38px;
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
  text-size-adjust: 11px;
}

.tooltip{
  z-index: 100;
  height: 40px;
  width: 220px;
  background-color:  #FF4747;
  border-radius: 4px;
  color: #fff;
  text-align: center;
  line-height: 40px;
  word-wrap: break-word;
  
}
.tooltip-arrow{
  height: 10px;
  width: 220px;
  background-image: url(../../assets/icon/tooltip-arrow.png);
  background-position: center;
  background-size: contain;
  background-repeat: no-repeat  ;
  
}
.tooltip-box{
  position: absolute;
  bottom:32px;
}

</style>