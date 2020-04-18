<p align="center">
  <img width="320" src="https://wpimg.wallstcn.com/ecc53a42-d79b-42e2-8852-5126b810a4c8.svg">
</p>

<p align="center">
  <a href="https://github.com/vuejs/vue">
    <img src="https://img.shields.io/badge/vue-2.6.10-brightgreen.svg" alt="vue">
  </a>
  <a href="https://github.com/ElemeFE/element">
    <img src="https://img.shields.io/badge/element--ui-2.7.0-brightgreen.svg" alt="element-ui">
  </a>
  <a href="https://travis-ci.org/PanJiaChen/vue-element-admin" rel="nofollow">
    <img src="https://travis-ci.org/PanJiaChen/vue-element-admin.svg?branch=master" alt="Build Status">
  </a>
  <a href="https://github.com/PanJiaChen/vue-element-admin/blob/master/LICENSE">
    <img src="https://img.shields.io/github/license/mashape/apistatus.svg" alt="license">
  </a>
  <a href="https://github.com/PanJiaChen/vue-element-admin/releases">
    <img src="https://img.shields.io/github/release/PanJiaChen/vue-element-admin.svg" alt="GitHub release">
  </a>
  <a href="https://gitter.im/vue-element-admin/discuss">
    <img src="https://badges.gitter.im/Join%20Chat.svg" alt="gitter">
  </a>
  <a href="https://panjiachen.github.io/vue-element-admin-site/donate">
    <img src="https://img.shields.io/badge/%24-donate-ff69b4.svg" alt="donate">
  </a>
</p>



## Introduction
Hi it is Vue element Admin template downloaded from (https://github.com/PanJiaChen/vue-element-admin). This template delete many component for starting new project.
This template has one Dashboard, Register, Login Component 
Installed 
-axios
-vue-echarts
-vue-emoji-picker
-vue-imask ... and more
## How Use 
# Install from 
    git clone https://github.com/mirjahongirbek/ElementAdminTemplate.git
# what is have
-In path src/store/module/lite.js has dashboard data
https://yadi.sk/i/ttGvR5-_teqxiw
 <p align="center">
  <img width="900" src="https://downloader.disk.yandex.ru/preview/04649177bded81d5af4d760a6a53210c7fe8712c4e9885a581cc74e73442d893/5e971cf4/75ok4E5a-7lP5V9PRoRYb3SsogIl6prYNoje8CA3s7hTM4acuE7-7nyxyedkSdU9gViaMMYKFizRIdiSZiPaNA==?uid=0&filename=1.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&tknv=v2&owner_uid=311822323&size=2048x2048">
</p>
-axios api
how to use
import api from "./plugin/api
Vue.use(api, {url:"http://yourDomain/api..."});
//use
this.$api.post("url",{data});
this.$api.get("/url");
this.$api.setToken("token") <-- Baerer Token
