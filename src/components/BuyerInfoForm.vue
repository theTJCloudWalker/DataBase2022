<template>
<el-form :model="BuyerInfo" label-width="120px">
    <el-form-item label="联系人姓名">
        <el-input v-model="BuyerInfo.BuyerName" />
    </el-form-item>
    <el-form-item label="联系电话">
        <el-input v-model="BuyerInfo.phone" />
    </el-form-item>
    <el-form-item label="联系邮箱">
        <el-input v-model="BuyerInfo.email" />
    </el-form-item>
</el-form>
                    
</template>

<script lang="ts">
export default {
    props:{
        BuyerInfo:{
            type: Object,
            required: true,
        }
    },
    setup(){

    }
}
</script>

<style>
</style>