<template>
  <div id="app">
    <Header />
    <Menu 
    @toggleMenu="toggleMenuOnClick" />
    <div :class="{ miniMenu: miniSize }">
    <Content />
    </div>
  </div>
</template>

<script>
import Header from "./components/layout/TheHeader.vue";
import Menu from "./components/layout/TheMenu.vue";
import Content from "./components/layout/TheContent.vue";
export default {
  name: "App",
  components: {
    Header,
    Menu,
    Content,
  },
  data() {
    return {
      miniSize: true,
    };
  },
  methods: {
    toggleMenuOnClick() {
      this.miniSize = !this.miniSize;
    },
  },
};
</script>

<style>
@import "./css/common/main.css";
</style>
