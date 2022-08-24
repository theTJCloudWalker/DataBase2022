<template>
  <div>
    <!-- **====================** -->
    <div class="topBar">
      <router-link to="/" class="topButton">
        <el-button>首页</el-button>
      </router-link>
    </div>
    <!-- **====================** -->
    <div class="form-container">
      <el-form label-width="120px" ref="TicketInquiry" :model="form">
        <!-- 地点输入 -->
        <el-row gutter="20">
          <el-col span="5">
            <el-form-item label="起始地">
              <el-input
                v-model="form.dep"
                size="large"
                placeholder="请输入起始地,例如：上海市"
                class="input"
              />
            </el-form-item>
          </el-col>
          <el-col span="5">
            <el-form-item label="目的地">
              <el-input
                v-model="form.des"
                size="large"
                placeholder="请输入目的地，例如：北京市"
                class="input"
              />
            </el-form-item>
          </el-col>
          <el-col span="5">
            <el-button
              type="primary"
              class="search"
              size="large"
              @click="ticketInquiry"
              >搜索</el-button
            >
          </el-col>
        </el-row>
        <!-- 地点输入结束 -->
        <!-- 单选：行程 对应变量：pass 值1、2、3对应不同选择 -->
        <div class="option">
          <el-form-item label="请选择行程类别">
            <el-radio-group v-model="form.pass">
              <el-radio label="1" size="large">单程</el-radio>
              <el-radio label="2" size="large">往返</el-radio>
              <el-radio label="3" size="large">多程</el-radio>
            </el-radio-group>
          </el-form-item>
        </div>
        <!-- 单选：行程结束 -->
        <!-- 舱类 变量：cabin-->
        <div class="option">
          <el-form-item label="请选择机舱类别">
            <el-radio-group v-model="form.cabin">
              <el-radio label="1" size="large">经济舱</el-radio>
              <el-radio label="2" size="large">公务舱</el-radio>
              <el-radio label="3" size="large">头等舱</el-radio>
            </el-radio-group>
          </el-form-item>
        </div>
        <!-- 舱类选择结束 -->
        <!-- 选择日期 -->
        <div class="select">
          请选择日期：
          <el-date-picker
            v-model="form.value1"
            type="daterange"
            range-separator="至"
            start-placeholder="起始日期"
            end-placeholder="结束日期"
            size="small"
          />
        </div>
        <!-- 选择日期结束 -->
        <!-- 展示搜索结果 -->
        <div class="searchResult">
          <br /><br />搜索结果:
          <el-table :data="flightTable" height="250" width="1200">
            <el-table-column type="selection" />
            <el-table-column prop="date" label="日期" width="200" />
            <el-table-column prop="flight" label="航班" width="150" />
            <el-table-column
              prop="departureSearch"
              label="起始地"
              width="100"
            />
            <el-table-column
              prop="departureAirplane"
              label="起飞机场"
              width="100"
            />
            <el-table-column
              prop="destinationSearch"
              label="目的地"
              width="100"
            />
            <el-table-column
              prop="destinationAirplane"
              label="降落机场"
              width="100"
            />
            <el-table-column prop="depTime" label="起飞时间" width="100" />
            <el-table-column prop="price" label="价格" width="100" />
          </el-table>
        </div>
        <!-- 搜索结果展示完毕 -->
        <div class="Buy">
          <el-button type="primary" @click="pay">支付</el-button>
        </div>
      </el-form>
    </div>
  </div>
</template>


<script>
import { ref } from "vue";
export default {
  name: "TicketInquiry",
  components: {},
  props: ["departure", "destination"], //没卵用，没法传参

  data() {
    return {
      /*======表单数据======*/
      form: {
        dep: this.departure, //出发日期
        des: this.destination, //目的地日期
        // dep:this.departure,
        // des:this.destination,
        pass: 0, //行程类别
        cabin: 0, //舱类
        value1: "",
      },
      /*============*/

      /*====应该从后端获得的数据=====*/
      flightTable: [
        {
          flight: "MU6060",
          date: "2016-05-03",
          departureSearch: "上海市",
          destinationSearch: "北京市",
          departureAirplane: "虹桥T1",
          destinationAirplane: "天安门",
          depTime: "10:30",
          price: "700",
        },
        {
          flight: "MU7060",
          date: "2016-05-03",
          departureSearch: "上海市",
          destinationSearch: "北京市",
          departureAirplane: "虹桥T1",
          destinationAirplane: "天安门",
          depTime: "10:30",
          price: "700",
        },
      ],
    };
  },

  methods: {
    /*======该方法是：通过点击按钮，向后端发送数据，然后返回得到的数据===*/
    ticketInquiry() {
      // ctx.$axios.post("url", );
      // console.log(this.departure);
    },

    //支付函数，可能要有支付页面 但是如何获取要支付的航班次的数据？
    pay(){

    }
  },

  /*=====数据、方法======*/
  // setup() {
  //   let pass = ref(0); //行程类别
  //   let cabin = ref(0); //舱类
  //   const value1 = ref(""); //date

  //   return {
  //     dep: this.departure, //出发日期
  //     des: "", //目的地日期
  //     // dep:this.departure,
  //     // des:this.destination,
  //     pass, //行程类别
  //     cabin, //舱类
  //     ifshow: 1,
  //     value1: "0",
  //     date: ["2000", "2021"],
  //     flightTable: [
  //       {
  //         date: "2016-05-03",
  //         departureSearch: "上海市",
  //         destinationSearch: "北京市",
  //         flight: "MU6060",
  //       },
  //     ],
  //   };
  // },
  /*====================*/
};
</script>


<style scoped>
/* 顶部栏 */
.topBar {
  display: inline-block;
  margin-bottom: 30px;
  border-style: solid;
  border-bottom-color: black;
  border-width: 0, 0, 0, 0;
  text-decoration: none;
}

/*  顶部按钮  */
.topButton {
  text-decoration: none;
}

/* 输入框 */
.input {
  width: 350px;
}

/* 选项 */
.option {
  margin-left: 55px;
  margin-top: 20px;
}

/* 选择 */
.select {
  margin-left: 55px;
  margin-top: 20px;
}

.topinfo {
  text-align: center;
  height: 50px;
}

/* 搜索结果 */
.searchResult {
  margin-left: 55px;
  margin-top: 20px;
  margin-right: 55px;
  border: #333;
  border-width: 1px;
}

/* 搜索按钮  */
.search {
  margin-left: 80px;
}

.Buy {
  text-align: right;
  margin-top: 20px;
  margin-right: 150px;
}

/*==========*/
.el-container {
  height: 100%;
}

.el-header,
.el-footer {
  background-color: #b3c0d1;
  color: #333;
  text-align: center;
  line-height: 60px;
}

.el-aside {
  background-color: #d3dce6;
  color: #333;
  text-align: center;
  line-height: 200px;
}

.el-main {
  background-color: #e9eef3;
  color: #333;
  text-align: center;
  line-height: 160px;
}

.el-menu {
  background-color: #d3dce6;
}
</style>