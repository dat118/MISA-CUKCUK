<template>
  <div>
    <div class="paging-bar">
      <div class="paging-left">
        <p>
          Hiển thị <b>{{ fromNumber }}-{{ toNumber }}/1000</b> nhân viên
        </p>
      </div>
      <div class="paging-center">
        <ButtonIcon
          shape="rectangle"
          idButton="first-page"
          iconChoose="icon-first-page"
          color="white"
          @btnClick="onBtnPageNumberClick('FirstPage')"
        />
        <ButtonIcon
          shape="rectangle"
          idButton="prev-page"
          iconChoose="icon-prev"
          color="white"
          @btnClick="onBtnPageNumberClick('PrevPage')"
        />
        <Button
          v-for="btnIndex in numberOfPage"
          :key="btnIndex"
          :Text="btnIndex + ''"
          :subClass="{ isActive: btnIndex == currentPageNumber }"
          shape="circle"
          color="white"
          @btnClick="onBtnPageNumberClick(btnIndex)"
        />
        <ButtonIcon
          shape="rectangle"
          idButton="next-page"
          iconChoose="icon-next"
          color="white"
          @btnClick="onBtnPageNumberClick('NextPage')"
        />
        <ButtonIcon
          shape="rectangle"
          idButton="last-page"
          iconChoose="icon-last-page"
          color="white"
          @btnClick="onBtnPageNumberClick('LastPage')"
        />
      </div>
      <div class="paging-right">
        <p>
          <b>{{ pageSize }}</b> nhân viên 1 trang
        </p>
        <div class="paging-arrow">
          <ButtonIcon
            :subClass="{ 'paging-up': true }"
            @btnClick="onBtnPageSizeOnClick('paging-up')"
          />
          <ButtonIcon
            :subClass="{ 'paging-down': true }"
            @btnClick="onBtnPageSizeOnClick('paging-down')"
          />
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Button from "../base/BaseButton.vue";
import ButtonIcon from "../base/BaseButtonIcon.vue";
export default {
  name: "PageNavigation",
  components: {
    Button,
    ButtonIcon,
  },
  props: {
    entityCount: Number,
    pageSize: Number,
    currentPageNumber: Number,
  },
  data() {
    return {
      numberOfPage: 5,
      fromNumber: 1,
      toNumber: 20,
    };
  },
  methods: {
    onBtnPageNumberClick(currentPageNumber) {
      let vm = this,
        pageNumber = 1;
      switch (currentPageNumber) {
        case "FirstPage":
          pageNumber = 1;
          break;
        case "PrevPage":
          pageNumber = Math.max(0, vm.currentPageNumber - 1);
          break;
        case "NextPage":
          pageNumber = Math.min(vm.numberOfPage, vm.currentPageNumber + 1);
          break;
        case "LastPage":
          pageNumber = vm.numberOfPage;
          break;
        default:
          pageNumber = currentPageNumber;
          break;
      }

      console.log(pageNumber);
      this.$emit("btnPageNumberOnClick", pageNumber);
    },
    onBtnPageSizeOnClick(direction) {
      let tmpPageSize = this.pageSize;
      if (direction == "paging-up") {
        tmpPageSize = this.pageSize + 10;
        if (tmpPageSize > 100) {
          tmpPageSize = 100;
        }
      } else {
        tmpPageSize = this.pageSize - 10;
        if (tmpPageSize < 10) {
          tmpPageSize = 10;
        }
      }
      this.$emit("btnPageSizeOnClick", tmpPageSize);
    },
  },
  mounted() {
    console.log(this.currentPageNumber);
  },
};
</script>
<style scoped>
@import url("../../css/layout/content.css");
</style>