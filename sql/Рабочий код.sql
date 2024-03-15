--������� �������� ���������, ������� �� ��������� ��������� ��� ���������� ������ �������, ����� �� ������� ������ ������ ��������.
--��������, ���� � �������� ���������� �������� 27 ������ 2014 ���� � 16 ������� 2014 ����, �� � ������ ������ ������� �����, �������
--� ������ ������(� 27 ������ �� 2 �������) ������ 15 �������, �� ������ (� 3 �� 9 �������) - ����������, � ������ (� 10 �� 16 �������) - ����. 
alter procedure Test
(
 @start date,
 @end date
)
as
begin
select distinct ���_������
from ������� inner join ����������_������� on �������.�����_������� =����������_�������.�����_������� 
where ����_������� between @start and @end  and ���_������ not in (
select ���_������
from 
(select  sum(����������)as ���, ���_������, DATEDIFF(week, @start, ����_�������)+1 as wk
from ������� inner join ����������_������� on �������.�����_������� =����������_�������.�����_������� 
where ����_������� between @start and @end 
group by ���_������, DATEDIFF(week, @start, ����_�������)+1) t1
where not exists(
select * from
(select  sum(����������)as ���, ���_������, DATEDIFF(week, @start, ����_�������)+1 as wk
from ������� inner join ����������_������� on �������.�����_������� =����������_�������.�����_�������
where ����_������� between @start and @end 
group by ���_������, DATEDIFF(week, @start, ����_�������)+1) t2 
where (t1.���_������ = t2.���_������ and t1.wk-1 =t2.wk and t1.���>t2.���)or t1.wk = 1))
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
select distinct ���_������
from ������� inner join ����������_������� on �������.�����_������� =����������_�������.�����_������� 
where ����_������� between @start and @end and ���_������ not in (
select  ���_������
from (select  sum(����������)as ���, ���_������, DATEDIFF(week, @start, ����_�������)+1 as wk
from ������� inner join ����������_������� on �������.�����_������� =����������_�������.�����_������� 
where ����_������� between @start and @end
group by ���_������, DATEDIFF(week, @start, ����_�������)+1) t1
where  exists(
select * from
(select  sum(����������)as ���, ���_������, DATEDIFF(week, @start, ����_�������)+1 as wk
from ������� inner join ����������_������� on �������.�����_������� =����������_�������.�����_�������
where ����_������� between @start and @end
group by ���_������, DATEDIFF(week, @start, ����_�������)+1) t2 
where t1.���_������ = t2.���_������ and t1.wk =t2.wk+1 and t1.���>t2.���))
end

execute Test1 @start='2022-11-20',
			  @end = '2022-12-10'


