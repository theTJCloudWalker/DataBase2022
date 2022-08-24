<template>
  <div class="background">
    <div class="buttonrow">
      <router-link to="/Myspace" class="toSpace">
        <el-button> 个人中心 </el-button>
      </router-link>
    </div>
    <!--  -->
    <div>
      <h1 class="title">欢迎使用机票订购系统</h1>
    </div>

    <div class="main">
      <el-form label-width="120px" ref="TicketInquiry">
        <!-- 地点输入 -->
        <el-row>
          <el-col span="5">
            <el-form-item label="起始地">
              <el-input
                v-model="departure"
                size="large"
                placeholder="请输入起始地,例如：上海市"
                class="input"
                :departure="departure"
              />
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col span="5">
            <el-form-item label="目的地">
              <el-input
                v-model="destination"
                size="large"
                placeholder="请输入目的地，例如：北京市"
                class="input"
                :destination="destination"
              />
            </el-form-item>
          </el-col>
          <el-col span="5">
            <router-link to="/TicketInquiry" class="search">
              <el-button type="primary" size="large" @click="toInquiry"
                >搜索</el-button
              >
            </router-link>
          </el-col>
        </el-row>
        <!-- 地点输入结束 -->
      </el-form>
    </div>
  </div>
</template>

<script lang="ts">
//import { defineComponent } from '@vue/composition-api'
import { ref } from "vue";
import TicketInquiry from "./TicketInquiry.vue";
import { useRouter } from "vue-router";

export default {
  name: "FrontPage",
  components: { TicketInquiry },
  data() {
    return {
      departure: "1",
      destination: "2",
    };
  },
};

// methods:{
//   toInquiry(){
//     this.$router.push(
//       {
//           path:'/TicketInquiry',
//           query:{
//             des:this.destination,
//             dep:this.departure
//           }
//       }
//     )
//   }

// data() {
//   return {
//     departure: "",
//     destination: "",
//   };
// },
</script>

<style scoped>
.background {
  background-color: aqua;
  position: absolute;
  width: 100%;
  height: 100%;
  background-image: url("../assets/img/Front.jpg");
  background-size: cover;
}

.buttonrow {
  margin-right: 50px;
  margin-top: 20px;
  text-align: right;
}

.main {
  margin-left: 420px;
  margin-top: 60px;
}

.title {
  margin-top: 100px;
  text-align: center;
  font-size: 50px;
}

.search {
  margin-left: 35px;
  text-decoration: none;
}

/* 输入框 */
.input {
  width: 350px;
}

.toSpace{
  text-align: right;
  text-decoration: none;
}
</style>