create table "USER"
(
    ID           VARCHAR2(9) not null
        constraint USER_PK
            primary key,
    NAME         VARCHAR2(20),
    PHONE_NUMBER VARCHAR2(11),
    PASSENGER_ID CHAR(18),
    PASSWORD     CHAR(64)
)
/

comment on column "USER".ID is '用户主码'
/

comment on column "USER".NAME is '用户姓名'
/

comment on column "USER".PHONE_NUMBER is '电话号码'
/

comment on column "USER".PASSENGER_ID is '身份证号'
/

comment on column "USER".PASSWORD is '用户密码(sha256)'
/

create table VIP
(
    ID      VARCHAR2(9) not null
        constraint VIP_PK
            primary key,
    USER_ID VARCHAR2(9)
        constraint VIP_USER_ID_FK
            references "USER",
    POINTS  NUMBER
)
/

comment on column VIP.ID is '会员主码'
/

comment on column VIP.USER_ID is '用户主码'
/

comment on column VIP.POINTS is '积分'
/

create table "ORDER"
(
    ID         CHAR(14) not null
        constraint ORDER_PK
            primary key,
    USER_ID    VARCHAR2(9)
        constraint ORDER_USER_ID_FK
            references "USER",
    ORDER_TIME TIMESTAMP(6),
    AMOUNT     NUMBER
)
/

comment on column "ORDER".ID is '订单号'
/

comment on column "ORDER".USER_ID is '用户主码'
/

comment on column "ORDER".ORDER_TIME is '订单时间戳'
/

comment on column "ORDER".AMOUNT is '订单金额'
/

create table INSURANCE
(
    COMPANY_NAME     VARCHAR2(50) not null,
    INSURANCE_NAME   VARCHAR2(30) not null,
    AMOUNT           NUMBER,
    INSURANCE_AMOUNT NUMBER,
    primary key (COMPANY_NAME, INSURANCE_NAME)
)
/

comment on column INSURANCE.COMPANY_NAME is '保险公司名'
/

comment on column INSURANCE.INSURANCE_NAME is '保险产品名'
/

comment on column INSURANCE.AMOUNT is '保险价格'
/

comment on column INSURANCE.INSURANCE_AMOUNT is '保险额'
/

create table INSURANCE_POLICY
(
    ID             CHAR(14) not null
        constraint INSURANCE_POLICY_PK
            primary key,
    PASSENGER_ID   CHAR(18),
    ORDER_ID       CHAR(14)
        constraint INSURANCE_POLICY_ORDER_ID_FK
            references "ORDER",
    COMPANY_NAME   VARCHAR2(50),
    INSURANCE_NAME VARCHAR2(30),
    constraint INSURANCE_POLICY_INSURANCE_COMPANY_NAME_INSURANCE_NAME_FK
        foreign key (COMPANY_NAME, INSURANCE_NAME) references INSURANCE
)
/

comment on column INSURANCE_POLICY.ID is '主码'
/

comment on column INSURANCE_POLICY.PASSENGER_ID is '身份证号'
/

comment on column INSURANCE_POLICY.ORDER_ID is '订单号'
/

comment on column INSURANCE_POLICY.COMPANY_NAME is '保险公司名'
/

comment on column INSURANCE_POLICY.INSURANCE_NAME is '保险产品名'
/

create table PASSENGER
(
    ID           CHAR(18) not null
        constraint PASSENGER_PK
            primary key,
    NAME         VARCHAR2(20),
    PHONE_NUMBER NUMBER,
    AGE          NUMBER
)
/

comment on column PASSENGER.ID is '旅客主码'
/

comment on column PASSENGER.NAME is '旅客姓名'
/

comment on column PASSENGER.PHONE_NUMBER is '电话'
/

comment on column PASSENGER.AGE is '年龄'
/

create table FLIGHT
(
    ID                VARCHAR2(6) not null
        constraint FLIGHT_PK
            primary key,
    AIRLINES_NAME     VARCHAR2(20),
    DEPARTURE_AIRPORT VARCHAR2(20),
    ARRIVAL_AIRPORT   VARCHAR2(20),
    DEPARTURE_TIME    TIMESTAMP(6),
    ARRIVAL_TIME      TIMESTAMP(6)
)
/

comment on column FLIGHT.ID is '航班主码'
/

comment on column FLIGHT.AIRLINES_NAME is '航空公司名'
/

comment on column FLIGHT.DEPARTURE_AIRPORT is '出发机场'
/

comment on column FLIGHT.ARRIVAL_AIRPORT is '到达机场'
/

comment on column FLIGHT.DEPARTURE_TIME is '计划出发时间'
/

comment on column FLIGHT.ARRIVAL_TIME is '计划到达时间'
/

create table FLIGHT_INSTANCE
(
    ID                    VARCHAR2(12) not null
        constraint FLIGHT_INSTANCE_PK
            primary key,
    FLIGHT_ID             VARCHAR2(6)
        constraint FLIGHT_INSTANCE_FLIGHT_ID_FK
            references FLIGHT,
    PLANE_TYPE            VARCHAR2(20),
    BOARDING_GATE         NUMBER,
    REALTIME_DISCOUNT     NUMBER(1, 2),
    ACTUAL_DEPARTURE_TIME TIMESTAMP(6),
    ACTUAL_ARRIVAL_TIME   TIMESTAMP(6)
)
/

comment on column FLIGHT_INSTANCE.ID is '航班实例主码'
/

comment on column FLIGHT_INSTANCE.FLIGHT_ID is '航班主码'
/

create table TICKET
(
    ID           CHAR(10) not null
        constraint TICKET_PK
            primary key,
    FLIGHT_ID    VARCHAR2(6)
        constraint TICKET_FLIGHT_INSTANCE_FLIGHT_ID_FK
            references FLIGHT_INSTANCE,
    INSTANCE_ID  VARCHAR2(12)
        constraint TICKET_FLIGHT_INSTANCE_ID_FK
            references FLIGHT_INSTANCE,
    PASSENGER_ID CHAR(18)
        constraint TICKET_PASSENGER_ID_FK
            references PASSENGER,
    ORDER_ID     CHAR(14)
        constraint TICKET_ORDER_ID_FK
            references "ORDER",
    SEAT_ID      CHAR(4),
    DISCOUNT     NUMBER(1, 2)
)
/

comment on column TICKET.ID is '机票主码'
/

comment on column TICKET.FLIGHT_ID is '航班主码'
/

comment on column TICKET.INSTANCE_ID is '航班实例主码'
/

comment on column TICKET.PASSENGER_ID is '身份证号'
/

comment on column TICKET.ORDER_ID is '订单主码'
/

comment on column TICKET.SEAT_ID is '座位主码'
/

comment on column TICKET.DISCOUNT is '折扣'
/

create table SEAT_TABLE
(
    FLIGHT_ID   VARCHAR2(6)  not null
        constraint SEAT_TABLE_FLIGHT_INSTANCE_FLIGHT_ID_FK
            references FLIGHT_INSTANCE,
    INSTANCE_ID VARCHAR2(12) not null
        constraint SEAT_TABLE_FLIGHT_INSTANCE_ID_FK
            references FLIGHT_INSTANCE,
    SEAT_ID     CHAR(4)      not null,
    AMOUNT      NUMBER,
    SOLD        CHAR,
    primary key (FLIGHT_ID, INSTANCE_ID, SEAT_ID)
)
/

comment on column SEAT_TABLE.FLIGHT_ID is '航班主码'
/

comment on column SEAT_TABLE.INSTANCE_ID is '航班实例主码'
/

comment on column SEAT_TABLE.SEAT_ID is '座位主码'
/

comment on column SEAT_TABLE.AMOUNT is '价格'
/

comment on column SEAT_TABLE.SOLD is '是否已售'
/

create table LUGGAGE
(
    ID           NUMBER,
    PASSENGER_ID CHAR(18)
        constraint LUGGAGE_PASSENGER_ID_FK
            references PASSENGER,
    TICKET_ID    CHAR(10)
        constraint LUGGAGE_TICKET_ID_FK
            references TICKET,
    WEIGHT       NUMBER
)
/

comment on column LUGGAGE.ID is '行李主码'
/

comment on column LUGGAGE.PASSENGER_ID is '身份证号'
/

comment on column LUGGAGE.TICKET_ID is '机票主码'
/

comment on column LUGGAGE.WEIGHT is '行李重量'
/

create table PASSENGER_TABLE
(
    USER_ID      VARCHAR2(9) not null
        constraint PASSENGER_TABLE_USER_ID_FK
            references "USER",
    PASSENGER_ID CHAR(18)    not null
        constraint PASSENGER_TABLE_PASSENGER_ID_FK
            references PASSENGER,
    primary key (USER_ID, PASSENGER_ID)
)
/

comment on column PASSENGER_TABLE.USER_ID is '用户主码'
/

comment on column PASSENGER_TABLE.PASSENGER_ID is '身份证号'
/

create table PRE_FLIGHT
(
    FLIGHT_ID VARCHAR2(6) not null
        constraint PRE_FLIGHT_FLIGHT_ID_FK
            references FLIGHT,
    PRE_ID    VARCHAR2(6) not null
        constraint PRE_FLIGHT_FLIGHT_ID_FK_2
            references FLIGHT,
    primary key (FLIGHT_ID, PRE_ID)
)
/

comment on column PRE_FLIGHT.FLIGHT_ID is '航班主码'
/

comment on column PRE_FLIGHT.PRE_ID is '前序航班id'
/

