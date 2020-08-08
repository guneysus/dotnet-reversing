   180001548:	40 53                	rex push rbx
   18000154a:	48 83 ec 20          	sub    rsp,0x20
   18000154e:	8b 05 dc b4 05 00    	mov    eax,DWORD PTR [rip+0x5b4dc]        # 0x18005ca30
   180001554:	48 8b d9             	mov    rbx,rcx
   180001557:	85 c0                	test   eax,eax
   180001559:	75 05                	jne    0x180001560
   18000155b:	e8 c4 fc ff ff       	call   0x180001224
   180001560:	8b 05 ca b4 05 00    	mov    eax,DWORD PTR [rip+0x5b4ca]        # 0x18005ca30
   180001566:	83 f8 02             	cmp    eax,0x2
   180001569:	75 0f                	jne    0x18000157a
   18000156b:	48 85 db             	test   rbx,rbx
   18000156e:	74 0a                	je     0x18000157a
   180001570:	48 8b 05 c9 b4 05 00 	mov    rax,QWORD PTR [rip+0x5b4c9]        # 0x18005ca40
   180001577:	48 89 03             	mov    QWORD PTR [rbx],rax
   18000157a:	8b 05 b0 b4 05 00    	mov    eax,DWORD PTR [rip+0x5b4b0]        # 0x18005ca30
   180001580:	48 83 c4 20          	add    rsp,0x20
   180001584:	5b                   	pop    rbx
   180001585:	c3                   	ret    