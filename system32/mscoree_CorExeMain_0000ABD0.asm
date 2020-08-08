   18000abd0:	40 53                	rex push rbx
   18000abd2:	48 83 ec 20          	sub    rsp,0x20
   18000abd6:	48 83 64 24 30 00    	and    QWORD PTR [rsp+0x30],0x0
   18000abdc:	48 8d 4c 24 30       	lea    rcx,[rsp+0x30]
   18000abe1:	e8 62 69 ff ff       	call   0x180001548
   18000abe6:	83 f8 01             	cmp    eax,0x1
   18000abe9:	0f 84 07 01 00 00    	je     0x18000acf6
   18000abef:	83 f8 03             	cmp    eax,0x3
   18000abf2:	75 64                	jne    0x18000ac58
   18000abf4:	48 8b 0d fd 21 05 00 	mov    rcx,QWORD PTR [rip+0x521fd]        # 0x18005cdf8
   18000abfb:	48 85 c9             	test   rcx,rcx
   18000abfe:	74 04                	je     0x18000ac04
   18000ac00:	33 db                	xor    ebx,ebx
   18000ac02:	eb 1c                	jmp    0x18000ac20
   18000ac04:	45 33 c0             	xor    r8d,r8d
   18000ac07:	48 8d 54 24 38       	lea    rdx,[rsp+0x38]
   18000ac0c:	41 8d 48 01          	lea    ecx,[r8+0x1]
   18000ac10:	e8 0f 19 00 00       	call   0x18000c524
   18000ac15:	8b d8                	mov    ebx,eax
   18000ac17:	85 c0                	test   eax,eax
   18000ac19:	78 2e                	js     0x18000ac49
   18000ac1b:	48 8b 4c 24 38       	mov    rcx,QWORD PTR [rsp+0x38]
   18000ac20:	48 8d 15 e9 e6 03 00 	lea    rdx,[rip+0x3e6e9]        # 0x180049310
   18000ac27:	48 ff 15 52 c0 03 00 	rex.W call QWORD PTR [rip+0x3c052]        # 0x180046c80
   18000ac2e:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   18000ac33:	48 85 c0             	test   rax,rax
   18000ac36:	0f 84 bf 00 00 00    	je     0x18000acfb
   18000ac3c:	ff 15 16 c4 03 00    	call   QWORD PTR [rip+0x3c416]        # 0x180047058
   18000ac42:	8b d8                	mov    ebx,eax
   18000ac44:	e9 b2 00 00 00       	jmp    0x18000acfb
   18000ac49:	8b c8                	mov    ecx,eax
   18000ac4b:	48 ff 15 de c0 03 00 	rex.W call QWORD PTR [rip+0x3c0de]        # 0x180046d30
   18000ac52:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   18000ac57:	cc                   	int3   
   18000ac58:	8b 05 62 10 05 00    	mov    eax,DWORD PTR [rip+0x51062]        # 0x18005bcc0
   18000ac5e:	85 c0                	test   eax,eax
   18000ac60:	0f 85 90 00 00 00    	jne    0x18000acf6
   18000ac66:	48 8b 05 e3 fd 04 00 	mov    rax,QWORD PTR [rip+0x4fde3]        # 0x18005aa50
   18000ac6d:	48 83 f8 ff          	cmp    rax,0xffffffffffffffff
   18000ac71:	75 1f                	jne    0x18000ac92
   18000ac73:	48 8b 4c 24 30       	mov    rcx,QWORD PTR [rsp+0x30]
   18000ac78:	48 8d 15 79 e6 03 00 	lea    rdx,[rip+0x3e679]        # 0x1800492f8
   18000ac7f:	48 ff 15 fa bf 03 00 	rex.W call QWORD PTR [rip+0x3bffa]        # 0x180046c80
   18000ac86:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   18000ac8b:	48 89 05 be fd 04 00 	mov    QWORD PTR [rip+0x4fdbe],rax        # 0x18005aa50
   18000ac92:	48 8b 05 b7 fd 04 00 	mov    rax,QWORD PTR [rip+0x4fdb7]        # 0x18005aa50
   18000ac99:	48 85 c0             	test   rax,rax
   18000ac9c:	74 14                	je     0x18000acb2
   18000ac9e:	48 8b 4c 24 28       	mov    rcx,QWORD PTR [rsp+0x28]
   18000aca3:	48 8b 05 a6 fd 04 00 	mov    rax,QWORD PTR [rip+0x4fda6]        # 0x18005aa50
   18000acaa:	ff 15 a8 c3 03 00    	call   QWORD PTR [rip+0x3c3a8]        # 0x180047058
   18000acb0:	eb 90                	jmp    0x18000ac42
   18000acb2:	48 8b 05 0f ff 04 00 	mov    rax,QWORD PTR [rip+0x4ff0f]        # 0x18005abc8
   18000acb9:	48 83 f8 ff          	cmp    rax,0xffffffffffffffff
   18000acbd:	75 1f                	jne    0x18000acde
   18000acbf:	48 8b 4c 24 30       	mov    rcx,QWORD PTR [rsp+0x30]
   18000acc4:	48 8d 15 45 e6 03 00 	lea    rdx,[rip+0x3e645]        # 0x180049310
   18000accb:	48 ff 15 ae bf 03 00 	rex.W call QWORD PTR [rip+0x3bfae]        # 0x180046c80
   18000acd2:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   18000acd7:	48 89 05 ea fe 04 00 	mov    QWORD PTR [rip+0x4feea],rax        # 0x18005abc8
   18000acde:	48 8b 05 e3 fe 04 00 	mov    rax,QWORD PTR [rip+0x4fee3]        # 0x18005abc8
   18000ace5:	48 85 c0             	test   rax,rax
   18000ace8:	74 0c                	je     0x18000acf6
   18000acea:	48 8b 05 d7 fe 04 00 	mov    rax,QWORD PTR [rip+0x4fed7]        # 0x18005abc8
   18000acf1:	e9 46 ff ff ff       	jmp    0x18000ac3c
   18000acf6:	bb 01 17 13 80       	mov    ebx,0x80131701
   18000acfb:	33 c9                	xor    ecx,ecx
   18000acfd:	e8 46 68 ff ff       	call   0x180001548
   18000ad02:	83 f8 01             	cmp    eax,0x1
   18000ad05:	75 05                	jne    0x18000ad0c
   18000ad07:	e8 e8 8e 00 00       	call   0x180013bf4
   18000ad0c:	8b c3                	mov    eax,ebx
   18000ad0e:	48 83 c4 20          	add    rsp,0x20
   18000ad12:	5b                   	pop    rbx
   18000ad13:	c3                   	ret    