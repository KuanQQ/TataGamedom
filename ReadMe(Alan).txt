Working On
    []��Index��detail��View

To Do

	[] �i�f���˲M��

	[]�h�f��

	[]�������c Pagination , RouteValueDictionary , 0040
	[]�ϯ��ܿ�J���n�z����
	[]�ϯ���
		�q�檬�A &  �q��s�� & ��ܴX��
		�q�檬�A OR �q��s��(��J���) & ��ܴX��

	[] ��ﰲ��� OrderItem�n�֩�������w�sitem

	Orders Create
	[] �f�A�l�ܥN�X�����H�e�覡e.g. 7-11 11�X 

	Suppliers
	[] import Excel �ɮ�����

	View�����~�T���ƪ��AIndex����r�m��

	OrderItemReturn
	[] C : �@��OrderItem�u��Q�h�f�@���A�U�ԲM�椣��ܤw�Q�h�f�L���ﶵ ; �ˬd�s���O�_����
	[] R : Index �h��/�h�f/���s�J�w �令��r ; Detail �����#,# �h�f��q��N�X�W�ߥX�� 
	[] U : Detail Edit �@��OrderItem�u��Q�h�f�@���A�U�ԲM�椣��ܤw�Q�h�f�L���ﶵ
	[] D

	Order

	InventoryItem
	[] �}�l�g�h���P�ɷs�W

	�վ�
	Orders
	[] C : []�s�W�q��P�q����ӦX�ֶi��
		   []Create OrderItem
		   []��w�I�� => �C�Ӥ�������� ; ��w�o�f => �H�e�饲�� ; ��w��F�Τw���f => ��F�������
		   []�f�A�l�ܥN�X�����H�e�覡e.g. 7-11 11�X,
		   []dataType => date�]�w�������ܤ��ѥH�᪺
	[] R : []Detail  OrderItem Create debug�A���令�s�W�q����Ӧܸӵ��q�� => ����e�ݳB�z;  
	[] U : []�U�Կ��T�ت��A������



	Inventory
	[] C : View �n��
	[] R : [v]Index View�n��
	   
		   [v]detail �C���W�ٿW�ߥX��
		   [] �s�W�z�����, �w��X����X
	[] D : ���S�Q���p���i�H�R�A�bUI�����N�ױ�


	StockInSheets
	[] C : Quantity? �ϥ��W��? ProductId? 
	[] R
	[] U : �Y�令�w�J�w�A��f��۰�getDate
	[] D

		#�Τ@�վ� 
		Edit dataType => �Sget���� �s�� ; Edit => �Sget����
		�ˬdVM ����Φ��� ��#,#  or �M�Φۭqattribution
		�M�歶 => �Ƨǿz�����

	[]Client Validation => JS

Completed
06/26
[v]Create EFModel
[v]Add Controller & View & LayOut2
[v]Add OrdersIndexVM, Add OrdersIndex Controller , Index View
[v]Orders Index()��T�h��, �諸����:DTO => IRepo => Repo => Services => Controller

06/27
[v]�s�WService,Repo�֬��@��
[v]�q�檬�A & [v]�q��s��(��J���)
[v]SelectList
[v]�椸����

6/28
[V]�Ƨǥ\�� Index CreatedAt Status*3 total  => ApplySort() �ǤJ�ѼƩ�IEnumarable (�wDebug)
[v]�Ƨǥ\�൲�X�z��\��, unitTest => TestGetUrl

06/29
[v]�Ƨǥ\�� Debug
[v]�����\��
�B�J
//View �I�s�s��
//���oService.Search(criteria, sortInfo).Count() �@��TotalRecords 
// �]�wPageInfo 
	property
	 => TotalRecords �z����Ƶ���, PageSize �C���X�� , PageNumber �I���ĴX��
	       Pages ��ܴX��(btn) 
	       PageItemCount(�w�]����?)
	       PageItemPrevNumber����btn��������
	       PageItemNextNumber����btn��������
	       PageBarItemCount(�w�]button��)

06/30
[v]Add Order Create() VM,Dto
[v]Order Create IRepo repo Service []�\�� => Index�s�X

07/01
[v] Order Create View Controller 
[v] Orders Create �ק�DataAnnotations&�U�ԲM��
[v] debug Index Sql
[v] Add Order Info()
[v] Order Edit Delete

07/02
[v] �w�sIndex  => Service Search()
[v] Debug Order Info  *��Ʈw�W�� ShipmentStatusCode���~
[v] ���z��Ѿl�w�s��SQL�y�k

07/03
[v] �w�s detail => �w�s����CRU
[v] �i�f��CRU

07/04
�h�f��
[v] Dto VM Exts
[v] CRUD

07/05
Orders Create
[v] ���ðh�f�B�h�ڿﶵ, �H�e�覡�U�Ԧ�debug
[v] �ˬd�|���s���O�_�s�b
[v] �q�槹�����>��F���>�H�e���>�q���� (�����@�b)

View => �q��D�ɪ�������q����Ӫ�������}�A�ӫ~�ϮM�� ; �^����
���ðh�f�B�h�ڿﶵ, �H�e�覡�U�Ԧ�debug
�e���e�{���b�s������q��
[v] D :  �s�W���Ū��D�ɥi�H�Q�R���B�Q���p���D�ɳQ�R���|�Q����
[v] �H�H�\��A�ݬO�_�ݭn�H�H; 
[v] �s�W�ۭq����

07/06
[v] �[�J����Controller SuppliersController ���տ�XCSV��
[v] Export() ���\��XCSV��
[v] Export() ���c��StringBuilder
[v] Export() Excel
[v] import Excel
	[v]Client => Server

07/09
	[v]�w�s�z��j�M
