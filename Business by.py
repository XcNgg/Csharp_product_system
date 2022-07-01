# encoding:utf-8
# !/usr/bin/python3
# @AUTHOR : XcNgg
# @IDE:PyCharm 2022.1
# @PROJECT:Net Crawler
# @FILE:Business by.py
# @TIME:2022/5/22 9:20

import random
import datetime
import sys
import time
from datetime import timedelta
import faker
import loguru
import pymysql
import requests
from lxml import etree


mysql_config = {
    "user": "CSharp",
    "password": 'J3Neiaz6fRkTcM4i',
    "host": "203.25.208.205",
    "db": "csharp",
    "charset": "utf8mb4"
}

try:
    print("正在连接MySQL...")
    mysql = pymysql.Connection(**mysql_config ,autocommit=True)
    cursor =mysql.cursor()
    print("MySQL【连接成功】")
except Exception as e:
    print("MySQL【连接失败】")
    sys.exit(0)
    print(e)

class Fake_Data:
    def to_client(self,fake):
        ClientName= fake.name()
        ClientAbbreviation = ClientName[random.randint(0,len(ClientName)-1):]
        ClientContacts = fake.name()
        ClientTelephone = fake.phone_number()
        ClientAddress =fake.address()
        ClientEmail =fake.email()
        #insertid = "Insert into Client(ClientId,ClientName,ClientAbbreviation,ClientContacts,ClientTelephone,ClientAddress,ClientEmail)" \
        #         " values('{}','{}','{}','{}','{}','{}','{}')".format(id,ClientName,ClientAbbreviation,ClientContacts,ClientTelephone,ClientAddress,ClientEmail)

        insert = "Insert into Client(ClientName,ClientAbbreviation,ClientContacts,ClientTelephone,ClientAddress,ClientEmail)" \
                 " values('{}','{}','{}','{}','{}','{}')".format(ClientName, ClientAbbreviation,
                                                                      ClientContacts, ClientTelephone, ClientAddress,
                                                                      ClientEmail)
        try:
            cursor.execute(insert)
            print("[+][to_client]  ", end="")
            print(insert)
        except Exception as e:
            print(e)
            mysql.rollback()

    def to_product(self,page):
        name_list,price_list=[],[]
        se = "select count(*) from Product"
        cursor.execute(se)
        now_num = cursor.fetchall()[0][0]
        t_name_list,t_price_list=self._get_product(page)
        name_list+=t_name_list
        price_list+=t_price_list
        add_num = len(name_list)
        description_list = [
            "新品发售！爆款好价！",
            "同价位天花板！"
            "能够用心造好车，靠的是大家的良好口碑来传播",
            "纵横千里，情系万家",
            "牛叉摩托，四通八达",
            "骑虎驱豹，威风凛凛",
            "骑上它，潇洒气派",
            "喧嚣都市中的一份冷静",
            "幸福摩托，行家的选择",
            "摩托力帆鲨，都市千里马",
            "劲在不言中",
            "欧陆风情，尽显豪爵",
            "完美典范，舍我“骑”谁",
            "中华天驹，纵横千里",
            "东方快车，华日摩托",
            "天荒地老，动力永恒",
            "日行千里，夜行八百",
            "环球-成功的开始！",
            "问苍茫大地，幸福的感觉。",
            "超高品质，值得信赖！",
            "科技动力，驾驭未来！",
            "让女司机教你骑摩托车，敢学否？",
            "功夫皇帝",
            "炙手可热",
        ]

        for num in range(add_num):
            insert = "insert into Product(ItemNo,ProductName,Description,ProductNumber,Price) " \
                     "values ('{}','{}','{}','{}','{}')".format(num+now_num+1,name_list[num],"[摩托]"+random.choice(description_list),random.randint(100,10000),price_list[num][1:])
            try:
                cursor.execute(insert)
                print("[+]【摩托产品】【to_prodcut】 ", end='')
                print(insert)
            except Exception as e:
                print(e)
                mysql.rollback()

    def to_orderdetail(self):
        ItemState_list =["未生产","生产中","已入库","已发货"]

        #得到订单数量
        se = "select count(OrderId) from Order_info;"
        cursor.execute(se)
        order_count = cursor.fetchall()[0][0]
        #得到产品数量
        se = "select count(*) from Product;"
        cursor.execute(se)
        pro = cursor.fetchall()[0][0]
        #随机产品ID
        ItemNo = random.randint(1, pro)
        #随机购买数量
        OrderNumber = random.randint(1, 101)
        #得到单价
        select_quantity = f"select Price from Product where ItemNo={ItemNo}"
        cursor.execute(select_quantity)
        Quantity = cursor.fetchall()[0][0]

        insert = "Insert into OrderDetail(OrderId,ItemNo,OrderNumber,Quantity,ItemState) " \
                 "values ('{}','{}','{}','{}','{}')".format(order_count+1,ItemNo,OrderNumber,Quantity,random.choice(ItemState_list))
        try:
            print("[+][to_orderdetail] ", end="")
            print(insert)
            cursor.execute(insert)
        except Exception as e:
            print(e)
            mysql.rollback()

        se = "select count(*) from Client;"
        cursor.execute(se)
        Client_id = cursor.fetchall()[0][0]
        self._to_order(Client_id,order_count+1)


    def _to_order(self,Client_id,order_count):
        OrderNotes_list = [
            "顺丰快递",
            "EMS快递",
            "京东物流",
            "跨越速运",
            "百世汇通",
            "宅急送",
            "中通快递",
            "上门到家",
            "天天快递",
            "申通快递"
        ]

        randomid = random.randint(1,Client_id)
        selcet_user = f"Select ClientName from Client where ClientId={randomid}"
        cursor.execute(selcet_user)
        ClientName = cursor.fetchall()[0][0]

        status_selcet =f"Select ItemState from OrderDetail where OrderId={order_count}"
        cursor.execute(status_selcet)
        ItemState= cursor.fetchall()[0][0]

        if ItemState =="未生产":
            OrderState = "配置原材料"
        elif ItemState == "已入库":
            OrderState= "成品已入库"
        else:
            OrderState = ItemState

        if OrderState =="已发货":
            nowtime = datetime.datetime.now()
            DeliveryDate = nowtime - timedelta(hours=random.randint(1, 100),minutes=random.randint(0, 59), seconds=random.randint(0, 59))
            PlannedDate = DeliveryDate - timedelta(hours=random.randint(100, 200),minutes=random.randint(0, 59), seconds=random.randint(0, 59))
            OrderData = PlannedDate - timedelta(days=random.randint(1,12),hours=random.randint(1,21),minutes=random.randint(0,59),seconds=random.randint(0,59))

        else:
            nowtime = datetime.datetime.now()
            OrderData = nowtime-timedelta(hours=random.randint(1, 100),minutes=random.randint(0, 59), seconds=random.randint(0, 59))

            PlannedDate = OrderData+timedelta(hours=random.randint(100, 200),minutes=random.randint(0, 59), seconds=random.randint(0, 59))

            DeliveryDate =PlannedDate  + timedelta(days=random.randint(1, 12), hours=random.randint(1, 21),
                                                minutes=random.randint(0, 59), seconds=random.randint(0, 59))

        OrderData = OrderData.strftime("%Y-%m-%d %H:%M:%S")
        PlannedDate = PlannedDate.strftime("%Y-%m-%d %H:%M:%S")
        DeliveryDate = DeliveryDate.strftime("%Y-%m-%d %H:%M:%S")
        insert = "Insert into Order_info(ClientName,OrderState,OrderData,PlannedDate,DeliveryDate,OrderNotes) " \
                 "values ('{}','{}','{}','{}','{}','{}')".format(ClientName, OrderState, OrderData, PlannedDate,
                                                                 DeliveryDate, random.choice(OrderNotes_list))
        try:
            print("[+][to_order] ", end="")
            cursor.execute(insert)
            print(insert)
        except Exception as e:
            mysql.rollback()
            print(e)

    def to_mark(self):
        ItemState_list =["未生产","生产中","已入库","已发货"]

        selectid = "select count(*) from Order_info"
        cursor.execute(selectid)
        orderid = cursor.fetchall()[0][0]
        odid = random.randint(1,orderid)

        se = "select count(*) from Product;"
        cursor.execute(se)
        pro = cursor.fetchall()[0][0]

        ItemNo = random.randint(1, pro)
        OrderNumber = random.randint(1, 101)
        select_quantity = f"select Price from Product where ItemNo={ItemNo}"
        cursor.execute(select_quantity)
        Quantity = cursor.fetchall()[0][0]
        insert = "Insert into OrderDetail(OrderId,ItemNo,OrderNumber,Quantity,ItemState) " \
                     "values ('{}','{}','{}','{}','{}')".format(odid,ItemNo,OrderNumber,Quantity,random.choice(ItemState_list))
        try:
            print("[+][to_orderdetail] ", end="")
            print(insert)
            cursor.execute(insert)
        except Exception as e:
            print(e)
            mysql.rollback()


    def _get_product(self,page):
        headers = {
            "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
            "Accept-Language": "zh-CN,zh;q=0.9",
            "Cache-Control": "no-cache",
            "Connection": "keep-alive",
            "Pragma": "no-cache",
            "Sec-Fetch-Dest": "document",
            "Sec-Fetch-Mode": "navigate",
            "Sec-Fetch-Site": "none",
            "Sec-Fetch-User": "?1",
            "Upgrade-Insecure-Requests": "1",
            "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.67 Safari/537.36",
            "sec-ch-ua": "^\\^",
            "sec-ch-ua-mobile": "?0",
            "sec-ch-ua-platform": "^\\^Windows^^"
        }
        cookies = {
            "countsql": "^%^5BS^%^5Fchexi^%^5Dwhere+1^%^3D1",
            "fenyecounts": "1218",
            "ASPSESSIONIDCGQSBSAA": "MFFCOIGBEPLOCONLAPOHBNNG"
        }
        url = f"https://www.2smoto.com/pinpai.asp?page=r{page}"
        params = {
            "ppt": "",
            "slx": "0",
            "skey": "",
            "page": ""
        }
        response = requests.get(url, headers=headers, cookies=cookies, params=params)
        html =etree.HTML(response.text)
        name_list = html.xpath("//ul[@class='goods_list']//li/p[@class='name']/a/text()")
        price_list = html.xpath("//ul[@class='goods_list']//li/p[@class='price_wrap']/span/text()")
        return  name_list,price_list


    def top_250book(self,page):
        headers = {
            "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
            "Accept-Language": "zh-CN,zh;q=0.9",
            "Cache-Control": "no-cache",
            "Connection": "keep-alive",
            "Pragma": "no-cache",
            "Referer": "https://www.google.com/",
            "Sec-Fetch-Dest": "document",
            "Sec-Fetch-Mode": "navigate",
            "Sec-Fetch-Site": "cross-site",
            "Sec-Fetch-User": "?1",
            "Upgrade-Insecure-Requests": "1",
            "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.67 Safari/537.36",
            "sec-ch-ua": "^\\^",
            "sec-ch-ua-mobile": "?0",
            "sec-ch-ua-platform": "^\\^Windows^^"
        }
        cookies = {
            }
        url = f"https://book.douban.com/top250?start={page}"
        response = requests.get(url, headers=headers, cookies=cookies)
        result = response.content.decode('utf-8')
        from lxml import etree
        html = etree.HTML(result)
        title = html.xpath("//div[@class='pl2']/a/text()")
        info = html.xpath("//p[@class='pl']/text()")
        tt_list = []
        for t in title:
            tt = t.replace('\n', '').replace(' ', '').replace('\t', '')
            if tt != '':
                tt_list.append(tt)
        price_list = []
        desription_list = []
        for inf in info:
            desription = ""
            ii = inf.split('/')
            for i in range(len(ii) - 1):
                desription += ii[i]
            desription_list.append(desription)
            try:
                price = int(inf.split('/')[-1].replace('元', '').split('.')[0].replace('NT$', '').replace('CNY', ''))
                if price == 0:
                    price = random.randint(10,100)
                price_list.append(price)
            except:
                loguru.logger.error(inf)


        for i in range(len(tt_list)):
            se = "select count(*) from Product"
            cursor.execute(se)
            now_num = cursor.fetchall()[0][0]
            insert = "insert into Product(ItemNo,ProductName,Description,ProductNumber,Price) " \
                     "values ('{}','{}','{}','{}','{}')".format( now_num + 1, tt_list[i],
                                                                '[书籍]'+desription_list[i],random.randint(100,10000),
                                                                price_list[i] )
            try:
                print("[+]【豆瓣书籍】【to_prodcut】 ", end='')
                print(insert)
                cursor.execute(insert)


            except Exception as e:
                print(e)
                mysql.rollback()

    def bqg(self,page):
        headers = {
            "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
            "Accept-Language": "zh-CN,zh;q=0.9",
            "Cache-Control": "no-cache",
            "Connection": "keep-alive",
            "Pragma": "no-cache",
            "Referer": "https://www.xbiquge.so/",
            "Sec-Fetch-Dest": "document",
            "Sec-Fetch-Mode": "navigate",
            "Sec-Fetch-Site": "same-origin",
            "Sec-Fetch-User": "?1",
            "Upgrade-Insecure-Requests": "1",
            "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.67 Safari/537.36",
            "sec-ch-ua": "^\\^",
            "sec-ch-ua-mobile": "?0",
            "sec-ch-ua-platform": "^\\^Windows^^"
        }
        url = f"https://www.xbiquge.so/top/allvisit/{page}.html"
        response = requests.get(url, headers=headers)
        from lxml import etree
        html = etree.HTML(response.text)
        title_list = html.xpath("//div[@class='novelslistss']//li/span[@class='s2']/a/text()")
        description_list = html.xpath("//div[@class='novelslistss']//li/span[@class='s3']/a/text()")

        for index in range(len(title_list)):
            se = "select count(*) from Product"
            cursor.execute(se)
            now_num = cursor.fetchall()[0][0]
            price = random.randint(30, 300)
            insert = "insert into Product(ItemNo,ProductName,Description,ProductNumber,Price) " \
                     "values ('{}','{}','{}','{}','{}')".format(now_num + 1, title_list[index],
                                                                '[书籍]' + description_list[index],
                                                                random.randint(100, 10000), price)
            try:
                print("[+]【笔趣阁小说】【to_prodcut】 ", end='')
                print(insert)
                cursor.execute(insert)

            except Exception as e:
                print(e)
                mysql.rollback()

    def tpy_phone(self,page):
        headers = {
            "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
            "Accept-Language": "zh-CN,zh;q=0.9",
            "Cache-Control": "no-cache",
            "Connection": "keep-alive",
            "Pragma": "no-cache",
            "Referer": "https://product.pconline.com.cn/mobile/25s1.shtml",
            "Sec-Fetch-Dest": "document",
            "Sec-Fetch-Mode": "navigate",
            "Sec-Fetch-Site": "same-origin",
            "Sec-Fetch-User": "?1",
            "Upgrade-Insecure-Requests": "1",
            "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.67 Safari/537.36",
            "sec-ch-ua": "^\\^",
            "sec-ch-ua-mobile": "?0",
            "sec-ch-ua-platform": "^\\^Windows^^"
        }
        cookies = {
            "_area_name_tag_": "nb"
        }
        url = f"https://product.pconline.com.cn/mobile/{page}s1.shtml"
        response = requests.get(url, headers=headers, cookies=cookies)
        from lxml import etree
        html = etree.HTML(response.text)
        title_list = html.xpath("//ul[@id='JlistItems']/li[@class='item']//div[@class='item-title']/h3/a/text()")
        description_list =[]
        price_list = []
        for i in range(1,len(title_list)+1):
            try:
                description_list.append(html.xpath(f"//li[@class='item'][{i}]//span[@class='item-title-des']/text()")[0])
            except:
                description_list.append("盲盒款")
            try:
                #
                price_list.append(html.xpath(f"//li[@class='item'][{i}]//div[@class='price price-now']/a/text()")[0])
            except:
                price_list.append(random.randint(800, 5999))

        for index in range(len(title_list)):
            se = "select count(*) from Product"
            cursor.execute(se)
            now_num = cursor.fetchall()[0][0]
            insert = "insert into Product(ItemNo,ProductName,Description,ProductNumber,Price) " \
                         "values ('{}','{}','{}','{}','{}')".format(now_num+1, title_list[index],
                                                                    '[手机]' + description_list[index],
                                                                    random.randint(1000,5000),
                                                                    int(str(price_list[index]).replace('￥', '')))
            try:
                print("[+]【太平洋手机】【to_prodcut】 ", end='')
                print(insert)
                cursor.execute(insert)

            except Exception as e:
                print(e)
                mysql.rollback()

    def tpy_notebook(self,page):
        headers = {
            "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
            "Accept-Language": "zh-CN,zh;q=0.9",
            "Cache-Control": "no-cache",
            "Connection": "keep-alive",
            "Pragma": "no-cache",
            "Referer": "https://product.pconline.com.cn/mobile/25s1.shtml",
            "Sec-Fetch-Dest": "document",
            "Sec-Fetch-Mode": "navigate",
            "Sec-Fetch-Site": "same-origin",
            "Sec-Fetch-User": "?1",
            "Upgrade-Insecure-Requests": "1",
            "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.67 Safari/537.36",
            "sec-ch-ua": "^\\^",
            "sec-ch-ua-mobile": "?0",
            "sec-ch-ua-platform": "^\\^Windows^^"
        }
        cookies = {
            "_area_name_tag_": "nb"
        }
        url = f"https://product.pconline.com.cn/notebook/{page}s1.shtml"
        response = requests.get(url, headers=headers, cookies=cookies)
        from lxml import etree
        html = etree.HTML(response.text)
        title_list = html.xpath("//ul[@id='JlistItems']/li[@class='item']//div[@class='item-title']/h3/a/text()")
        description_list = []
        price_list = []
        for i in range(1, len(title_list) + 1):
            try:
                description_list.append(
                    html.xpath(f"//li[@class='item'][{i}]//span[@class='item-title-des']/text()")[0])
            except:
                description_list.append("盲盒款")
            try:
                price_list.append(html.xpath(f"//li[@class='item'][{i}]//div[@class='price price-now']/a/text()")[0])
            except:
                price_list.append(random.randint(800, 5999))

        for index in range(len(title_list)):
            se = "select count(*) from Product"
            cursor.execute(se)
            now_num = cursor.fetchall()[0][0]
            insert = "insert into Product(ItemNo,ProductName,Description,ProductNumber,Price) " \
                     "values ('{}','{}','{}','{}','{}')".format(now_num+1, title_list[index],
                                                                '[笔记本/平板]' + description_list[index],
                                                                random.randint(3000, 7000),
                                                                int(str(price_list[index].split('-')[0]).replace('￥',
                                                                                                                 '')))
            try:
                print("[+]【太平洋笔记本/平板】【to_prodcut】 ", end='')
                print(insert)
                cursor.execute(insert)

            except Exception as e:
                print(e)
                mysql.rollback()


    def tpy_pc(self,page):
        headers = {
            "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
            "Accept-Language": "zh-CN,zh;q=0.9",
            "Cache-Control": "no-cache",
            "Connection": "keep-alive",
            "Pragma": "no-cache",
            "Referer": "https://product.pconline.com.cn/mobile/25s1.shtml",
            "Sec-Fetch-Dest": "document",
            "Sec-Fetch-Mode": "navigate",
            "Sec-Fetch-Site": "same-origin",
            "Sec-Fetch-User": "?1",
            "Upgrade-Insecure-Requests": "1",
            "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.67 Safari/537.36",
            "sec-ch-ua": "^\\^",
            "sec-ch-ua-mobile": "?0",
            "sec-ch-ua-platform": "^\\^Windows^^"
        }
        cookies = {
            "_area_name_tag_": "nb"
        }
        url = f"https://product.pconline.com.cn/pc/{page}s1.shtml"
        response = requests.get(url, headers=headers, cookies=cookies)
        from lxml import etree
        html = etree.HTML(response.text)
        title_list = html.xpath("//ul[@id='JlistItems']/li[@class='item']//div[@class='item-title']/h3/a/text()")
        description_list = []
        price_list = []
        for i in range(1, len(title_list) + 1):
            try:
                description_list.append(
                    html.xpath(f"//li[@class='item'][{i}]//span[@class='item-title-des']/text()")[0])
            except:
                description_list.append("盲盒款")
            try:
                #
                price_list.append(html.xpath(f"//li[@class='item'][{i}]//div[@class='price price-now']/a/text()")[0])
            except:
                price_list.append(random.randint(800, 5999))

        for index in range(len(title_list)):
            se = "select count(*) from Product"
            cursor.execute(se)
            now_num = cursor.fetchall()[0][0]
            insert = "insert into Product(ItemNo,ProductName,Description,ProductNumber,Price) " \
                     "values ('{}','{}','{}','{}','{}')".format(now_num+1, title_list[index],
                                                                '[电脑配件]' + description_list[index],
                                                                random.randint(2000, 10000),
                                                                int(str(price_list[index]).replace('￥', '')))
            try:
                print("[+]【太平洋电脑配件】【to_prodcut】 ", end='')
                print(insert)
                cursor.execute(insert)

            except Exception as e:
                print(e)
                mysql.rollback()


def home():
    print("---请输入对应需求对应的序号---")
    print("---如果当前数据表为空,请先添加客户，再添加产品,最后添加订单---")
    print("【0】 退出")
    print("【1】 添加新客户")
    print("【2】 添加摩托产品")
    print("【3】 添加新订单与详细信息")
    print("【4】 添加所属订单")
    print("【5】 添加豆瓣书籍")
    print("【6】 添加笔趣阁小说")
    print("【7】 添加手机产品")
    print("【8】 添加笔记本/平板产品[无页数控制]")
    print("【9】 添加电脑配件产品")


def check_flag(myfake,flag):
    #    print("【1】 添加新客户")
    if flag ==1:
        try:
            n = int(input("需求客户数量:"))
        except Exception as e:
            loguru.logger.error("错误的客户数量！")
            #自动添加10个客户的伪数据
        else:
            for i in range(n):
                #设置地区
                fake = faker.Faker(random.choice(["zh_TW", 'zh_CN', 'en_US', 'en_GB', 'de_DE', 'ja_JP']))
                myfake.to_client(fake)

    # print("【2】 爬取添加摩托产品")
    elif flag ==2:
        # 自动添加产品
        try:
            start = int(input("起始页数【最小为1】:"))
        except:
            loguru.logger.error("错误的起始页数！")
        else:
            try:
                end = int(input("结束页数【最大为31】"))
            except:
                loguru.logger.error("错误的结束页数！")
            else:
                if (start < 1 or end > 31):
                    loguru.logger.error("错误的页数！【最小为1,最大为31】")
                else:
                    for i in range(start,end+1):
                        thread = threading.Thread(target=myfake.to_product, args=(i,))
                        thread.run()

    #    print("【3】 添加新订单与详细信息")
    elif flag ==3:
        try:
            n = int(input("需求单数:"))
            # 自动添加10条订单及订单详细信息
        except Exception as e:
            loguru.logger.error("错误的单数！")
        else:
            for i in range(n):
                thread = threading.Thread(target=myfake.to_orderdetail, args=())
                thread.run()

    #    print("【4】 添加所属订单")
    elif flag ==4:
        try:
            n = int(input("需求单数:"))
        except:
            loguru.logger.error("错误的单数！")
            # 自动添加10条订单及订单详细信息
        else:
            for i in range(n):
                thread = threading.Thread(target=myfake.to_mark, args=())
                thread.run()

    #    print("【5】 爬取添加豆瓣书籍250本")
    elif flag ==5:
        try:
            start = int(input("起始页数【最小为0】:"))
        except:
            loguru.logger.error("错误的起始页数！")
        else:
            try:
                end = int(input("结束页数【最大为10】"))
            except:
                loguru.logger.error("错误的结束页数！")
            else:
                if (start<0 or end>10):
                    loguru.logger.error("错误的页数！【最小为0,最大为10】")
                else:
                    for i in range(start*25,(end+1)*25, 25):
                        thread = threading.Thread(target=myfake.top_250book, args=(i,))
                        thread.run()
    #    print("【6】 爬取添加笔趣阁小说")
    elif flag ==6:
        try:
            start = int(input("起始页数【最小为1】:"))
        except:
            loguru.logger.error("错误的起始页数！")
        else:
            try:
                end = int(input("结束页数【最大为1106】"))
            except:
                loguru.logger.error("错误的结束页数！")
            else:
                if (start<=0 or end>1106):
                    loguru.logger.error("错误的页数！【最小为1,最大为1106】")
                else:
                    for i in range(start, end+1):
                        thread = threading.Thread(target=myfake.bqg, args=(i,))
                        thread.run()
    #print("【7】 爬取手机产品")
    elif flag ==7:
        try:
            start = int(input("起始页数【最小为0】:"))
        except:
            loguru.logger.error("错误的起始页数！")
        else:
            try:
                end = int(input("结束页数【最大为20】"))
            except:
                loguru.logger.error("错误的结束页数！")
            else:
                if (start < 0 or end > 20):
                    loguru.logger.error("错误的页数！【最小为1,最大为1106】")
                else:
                    for i in range(start*25, (end+1)*25,25):
                        thread = threading.Thread(target=myfake.tpy_phone, args=(i,))
                        thread.run()

    #print("【8】 爬取笔记本/平板产品")
    elif flag ==8:
        for i in range(0,183,25):
            thread = threading.Thread(target=myfake.tpy_notebook, args=(i,))
            thread.run()

    #print("【9】 爬取电脑配件产品")
    elif flag ==9:
        try:
            start = int(input("起始页数【最小为0】:"))
        except:
            loguru.logger.error("错误的起始页数！")
        else:
            try:
                end = int(input("结束页数【最大为182】"))
            except:
                loguru.logger.error("错误的结束页数！")
            else:
                if (start < 0 or end > 182):
                    loguru.logger.error("错误的页数！【最小为1,最大为1106】")
                else:
                    for i in range(start*25, (end+1)*25,25):
                        thread = threading.Thread(target=myfake.tpy_pc, args=(i,))
                        thread.run()


    #print("退出")
    elif flag ==0:
        mysql.close()
        print("See You ~")
        loguru.logger.info("MySQL 已关闭连接")
        sys.exit(0)

    else:
        loguru.logger.error("请输入正确的编号!")




if __name__ == '__main__':
    import threading
    myfake = Fake_Data()
    while True:
        home()
        try:
            time.sleep(0.2)
            flag = int(input("请输入: "))
        except Exception as e:
            loguru.logger.error("错误的序号！")
        else:
            check_flag(myfake,flag)










