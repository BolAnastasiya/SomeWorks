--Создать хранимую процедуру, которая по заданному диапазону дат определяет список товаров, спрос на которые каждую неделю снижался.
--Например, если в качестве параметров передать 27 января 2014 года и 16 февраля 2014 года, то в список должен попасть товар, который
--в первую неделю(с 27 января по 2 февраля) купили 15 человек, во вторую (с 3 по 9 февраля) - тринадцать, в третью (с 10 по 16 февраля) - семь. 
alter procedure Test
(
 @start date,
 @end date
)
as
begin
select distinct код_товара
from Покупки inner join Содержимое_покупок on Покупки.номер_покупки =Содержимое_покупок.номер_покупки 
where дата_покупки between @start and @end  and код_товара not in (
select код_товара
from 
(select  sum(количество)as кол, код_товара, DATEDIFF(week, @start, дата_покупки)+1 as wk
from Покупки inner join Содержимое_покупок on Покупки.номер_покупки =Содержимое_покупок.номер_покупки 
where дата_покупки between @start and @end 
group by код_товара, DATEDIFF(week, @start, дата_покупки)+1) t1
where not exists(
select * from
(select  sum(количество)as кол, код_товара, DATEDIFF(week, @start, дата_покупки)+1 as wk
from Покупки inner join Содержимое_покупок on Покупки.номер_покупки =Содержимое_покупок.номер_покупки
where дата_покупки between @start and @end 
group by код_товара, DATEDIFF(week, @start, дата_покупки)+1) t2 
where (t1.код_товара = t2.код_товара and t1.wk-1 =t2.wk and t1.кол>t2.кол)or t1.wk = 1))
end

execute Test @start='2022-11-20',
			 @end = '2022-12-10'



create procedure Test1
(
 @start date,
 @end date
)
as
begin
select distinct код_товара
from Покупки inner join Содержимое_покупок on Покупки.номер_покупки =Содержимое_покупок.номер_покупки 
where дата_покупки between @start and @end and код_товара not in (
select  код_товара
from (select  sum(количество)as кол, код_товара, DATEDIFF(week, @start, дата_покупки)+1 as wk
from Покупки inner join Содержимое_покупок on Покупки.номер_покупки =Содержимое_покупок.номер_покупки 
where дата_покупки between @start and @end
group by код_товара, DATEDIFF(week, @start, дата_покупки)+1) t1
where  exists(
select * from
(select  sum(количество)as кол, код_товара, DATEDIFF(week, @start, дата_покупки)+1 as wk
from Покупки inner join Содержимое_покупок on Покупки.номер_покупки =Содержимое_покупок.номер_покупки
where дата_покупки between @start and @end
group by код_товара, DATEDIFF(week, @start, дата_покупки)+1) t2 
where t1.код_товара = t2.код_товара and t1.wk =t2.wk+1 and t1.кол>t2.кол))
end

execute Test1 @start='2022-11-20',
			  @end = '2022-12-10'


