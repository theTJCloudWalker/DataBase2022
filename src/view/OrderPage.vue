<template>
  <div class="common-layout">
    <el-container>
      <el-container class="container">
        <el-main class="main">
            <div class="tips">
                受新冠疫情影响，出行请注意安全
            </div>
            <div class="passenger">
                选择乘车人：<br>
                 <el-checkbox-group v-model="PassengerBuyOptions">
                    <el-col v-for="(item, index) in PassengerInfoGroupPem">
                        <el-checkbox  :key="index" :label="item.id" size="large">{{item.name}} {{item.phone}}  </el-checkbox>
                        <span class="icon-content">
                          <el-icon :size="20"><Edit /></el-icon>
                          修改信息
                        </span>  
                        
                    </el-col>
                    <el-button>添加乘客</el-button>
                </el-checkbox-group>

            </div>
             <el-divider />
            <div class="contact-box">
                <div class="box-title">联系人</div>
                <div class="info-card">
                   <BuyerInfoForm :BuyerInfo="BuyerInfo"/>
                </div>
            </div>
            <div class="insurance-box">
                保险勾选
            </div>
        </el-main>
        <el-aside class="sidebar">
            <div><!-- 飞机图标（仿照携程样式） -->
             <el-descriptions title="机票详情" direction="vertical" :column="4" :size="size" border>
                <el-descriptions-item label="航班班次">MU7k32</el-descriptions-item>
                <el-descriptions-item label="出发时间">18:00</el-descriptions-item>
                <el-descriptions-item label="抵达时间" :span="2">20:00</el-descriptions-item>
                <el-descriptions-item label="航空公司">东方航空</el-descriptions-item>
                <el-descriptions-item label="抵达地点">上海虹桥国际机场</el-descriptions-item>
            </el-descriptions>
            </div>
            <el-divider />
            <div class="payOut">
                金额结算
                <div class="cost-detail">
                  <div class="cost-row">
                    <div class="cost-tit">机建</div>
                    <div class="corner">¥50 x 1</div>
                 </div>
                 <div class="cost-row">
                    <div class="cost-tit">燃油费</div>
                    <div class="corner">¥130 x 1</div>
                 </div>
                </div>
                 
            </div>
            <el-divider />
            <div class="pay-button">
              <el-button type="primary" round>支付</el-button>
            </div>
            
        </el-aside>
      </el-container>
    </el-container>
  </div>
</template>


<script>
import { computed, ref } from 'vue'

import { BuyerInfo } from "@/utils/BuyerValidators";
import BuyerInfoForm from "@/components/BuyerInfoForm.vue";

const checkList = ref(['Option A'])
console.log(checkList);
export default {
    data() {
    return {
      PassengerBuyOptions: [],
      PassengerInfoGroupPem: [
        {
          id: "1",
          name: '张三',
          phone:'112233'
        },{
          id: "2",
          name: '李四',
          phone:'334455'
        },{
          id: "3",
          name: '王五',
          phone:'667788'
        }
      ],
    }
  },
   components:{BuyerInfoForm},
   setup(){
        return{
            BuyerInfo
        }
   }
}
const size = ref('')
const blockMargin = computed(() => {
  const marginMap = {
    large: '32px',
    default: '28px',
    small: '24px',
  }
  return {
    marginTop: marginMap[size.value] || marginMap.default,
  }
})

</script>

<style>

div{
    display: block;
}

.common-layout{
      background: linear-gradient(to bottom, rgb(192, 255, 255), white);
}


.container {
    position: relative;
    width: 1250px;
    margin: 0 auto;
    margin-top: 10px;
}

/*顶栏*/
.header-wrapper {
    width: 100%;
    height: 80px;
    background: #fff;
    border-bottom: 1px solid #d6dde2;
}

/*主位盒子*/ 
.main {
    position: relative;
    float: left;
    width: 780px;
    min-height: 500px;
    padding-top: 10px;
    background: #fdfeff;
    margin-right: 20px;
}


.el-descriptions {
  margin-top: 20px;
}

.contact-box .info-card {
    padding: 5px 20px 15px;
}

.info-card {
    position: relative;
    margin-bottom: 10px;
    padding: 0 20px;
    background: #fff;
}

.box-title{
    position: relative;
    margin-bottom: 10px;
    color: #849bab;
}

/* 侧边盒子 */
.payOut{
  padding: 10px 30px;
}
.sidebar {
    float: right;
    width: 400px;
    background-color: #fdfdfd;
    border: 1px solid #d6dde2;
}

.cost-row {
    position: relative;
    line-height: 27px;
    padding-right: 80px;
}

.cost-row .corner {
    position: absolute;
    right: 0;
    top: 0;
    text-align: right;
}

.cost-detail {
    font-size: 12px;
    padding: 12px 0;
    border-top: 1px dashed #b4c4d6;
}

.pay-button{
  margin:0 auto;
  position: absolute;
  text-align: center;
  width: 398px;
}

.icon-content{
  height: 40px;
  padding-left: 10px;
  font-size: 12px;
}
</style>