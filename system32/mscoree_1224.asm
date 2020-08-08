   180001224:	48 8b c4             	mov    rax,rsp
   180001227:	48 89 58 08          	mov    QWORD PTR [rax+0x8],rbx
   18000122b:	48 89 70 10          	mov    QWORD PTR [rax+0x10],rsi
   18000122f:	48 89 78 18          	mov    QWORD PTR [rax+0x18],rdi
   180001233:	4c 89 68 20          	mov    QWORD PTR [rax+0x20],r13
   180001237:	55                   	push   rbp
   180001238:	41 56                	push   r14
   18000123a:	41 57                	push   r15
   18000123c:	48 8d a8 68 fe ff ff 	lea    rbp,[rax-0x198]
   180001243:	48 81 ec 80 02 00 00 	sub    rsp,0x280
   18000124a:	48 8b 05 0f 88 05 00 	mov    rax,QWORD PTR [rip+0x5880f]        # 0x180059a60
   180001251:	48 33 c4             	xor    rax,rsp
   180001254:	48 89 85 70 01 00 00 	mov    QWORD PTR [rbp+0x170],rax
   18000125b:	48 83 64 24 48 00    	and    QWORD PTR [rsp+0x48],0x0
   180001261:	48 8d 0d 90 99 04 00 	lea    rcx,[rip+0x49990]        # 0x18004abf8
   180001268:	33 ff                	xor    edi,edi
   18000126a:	45 33 c0             	xor    r8d,r8d
   18000126d:	33 d2                	xor    edx,edx
   18000126f:	89 7c 24 50          	mov    DWORD PTR [rsp+0x50],edi
   180001273:	e8 c8 a6 00 00       	call   0x18000b940
   180001278:	45 33 c0             	xor    r8d,r8d
   18000127b:	48 8d 0d 16 9a 04 00 	lea    rcx,[rip+0x49a16]        # 0x18004ac98
   180001282:	33 d2                	xor    edx,edx
   180001284:	48 8b d8             	mov    rbx,rax
   180001287:	e8 b4 a6 00 00       	call   0x18000b940
   18000128c:	44 8d 6f 01          	lea    r13d,[rdi+0x1]
   180001290:	48 8b f0             	mov    rsi,rax
   180001293:	48 85 db             	test   rbx,rbx
   180001296:	74 24                	je     0x1800012bc
   180001298:	48 85 c0             	test   rax,rax
   18000129b:	74 1f                	je     0x1800012bc
   18000129d:	33 d2                	xor    edx,edx
   18000129f:	48 8b cb             	mov    rcx,rbx
   1800012a2:	e8 f9 fd ff ff       	call   0x1800010a0
   1800012a7:	85 c0                	test   eax,eax
   1800012a9:	74 11                	je     0x1800012bc
   1800012ab:	48 8b ce             	mov    rcx,rsi
   1800012ae:	e8 fd ee 01 00       	call   0x1800201b0
   1800012b3:	33 c0                	xor    eax,eax
   1800012b5:	48 89 5c 24 48       	mov    QWORD PTR [rsp+0x48],rbx
   1800012ba:	eb 3e                	jmp    0x1800012fa
   1800012bc:	48 8b cb             	mov    rcx,rbx
   1800012bf:	e8 ec ee 01 00       	call   0x1800201b0
   1800012c4:	48 8b ce             	mov    rcx,rsi
   1800012c7:	e8 e4 ee 01 00       	call   0x1800201b0
   1800012cc:	48 21 7c 24 30       	and    QWORD PTR [rsp+0x30],rdi
   1800012d1:	4c 8d 0d c8 fd ff ff 	lea    r9,[rip+0xfffffffffffffdc8]        # 0x1800010a0
   1800012d8:	44 89 6c 24 28       	mov    DWORD PTR [rsp+0x28],r13d
   1800012dd:	48 8d 4c 24 48       	lea    rcx,[rsp+0x48]
   1800012e2:	48 21 7c 24 20       	and    QWORD PTR [rsp+0x20],rdi
   1800012e7:	45 33 c0             	xor    r8d,r8d
   1800012ea:	33 d2                	xor    edx,edx
   1800012ec:	e8 0b 5f 01 00       	call   0x1800171fc
   1800012f1:	8b 7c 24 50          	mov    edi,DWORD PTR [rsp+0x50]
   1800012f5:	48 8b 5c 24 48       	mov    rbx,QWORD PTR [rsp+0x48]
   1800012fa:	48 85 db             	test   rbx,rbx
   1800012fd:	41 0f 45 fd          	cmovne edi,r13d
   180001301:	89 7c 24 50          	mov    DWORD PTR [rsp+0x50],edi
   180001305:	48 8d 3d 94 7d 04 00 	lea    rdi,[rip+0x47d94]        # 0x1800490a0
   18000130c:	85 c0                	test   eax,eax
   18000130e:	0f 88 a0 01 00 00    	js     0x1800014b4
   180001314:	4c 8d 44 24 60       	lea    r8,[rsp+0x60]
   180001319:	48 8b d3             	mov    rdx,rbx
   18000131c:	48 8b cf             	mov    rcx,rdi
   18000131f:	e8 14 02 01 00       	call   0x180011538
   180001324:	85 c0                	test   eax,eax
   180001326:	0f 88 88 01 00 00    	js     0x1800014b4
   18000132c:	48 8d 4c 24 60       	lea    rcx,[rsp+0x60]
   180001331:	e8 86 f4 01 00       	call   0x1800207bc
   180001336:	85 c0                	test   eax,eax
   180001338:	0f 84 76 01 00 00    	je     0x1800014b4
   18000133e:	4c 8d 4c 24 58       	lea    r9,[rsp+0x58]
   180001343:	48 8b d3             	mov    rdx,rbx
   180001346:	48 8b cf             	mov    rcx,rdi
   180001349:	e8 ba 03 01 00       	call   0x180011708
   18000134e:	85 c0                	test   eax,eax
   180001350:	78 6e                	js     0x1800013c0
   180001352:	48 8b 7c 24 58       	mov    rdi,QWORD PTR [rsp+0x58]
   180001357:	48 85 ff             	test   rdi,rdi
   18000135a:	74 64                	je     0x1800013c0
   18000135c:	48 8d 15 5d 7d 04 00 	lea    rdx,[rip+0x47d5d]        # 0x1800490c0
   180001363:	48 8b cf             	mov    rcx,rdi
   180001366:	48 ff 15 13 59 04 00 	rex.W call QWORD PTR [rip+0x45913]        # 0x180046c80
   18000136d:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   180001372:	48 8d 15 67 7d 04 00 	lea    rdx,[rip+0x47d67]        # 0x1800490e0
   180001379:	48 8b cf             	mov    rcx,rdi
   18000137c:	48 8b f0             	mov    rsi,rax
   18000137f:	48 ff 15 fa 58 04 00 	rex.W call QWORD PTR [rip+0x458fa]        # 0x180046c80
   180001386:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   18000138b:	48 8d 15 6e 7d 04 00 	lea    rdx,[rip+0x47d6e]        # 0x180049100
   180001392:	48 8b cf             	mov    rcx,rdi
   180001395:	4c 8b f8             	mov    r15,rax
   180001398:	48 ff 15 e1 58 04 00 	rex.W call QWORD PTR [rip+0x458e1]        # 0x180046c80
   18000139f:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   1800013a4:	4c 8b f0             	mov    r14,rax
   1800013a7:	48 85 f6             	test   rsi,rsi
   1800013aa:	75 21                	jne    0x1800013cd
   1800013ac:	4d 85 ff             	test   r15,r15
   1800013af:	75 1c                	jne    0x1800013cd
   1800013b1:	48 8b cf             	mov    rcx,rdi
   1800013b4:	48 ff 15 d5 58 04 00 	rex.W call QWORD PTR [rip+0x458d5]        # 0x180046c90
   1800013bb:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   1800013c0:	48 8d 54 24 60       	lea    rdx,[rsp+0x60]
   1800013c5:	41 8b cd             	mov    ecx,r13d
   1800013c8:	e9 ef 00 00 00       	jmp    0x1800014bc
   1800013cd:	48 8d 15 44 7d 04 00 	lea    rdx,[rip+0x47d44]        # 0x180049118
   1800013d4:	48 8b cf             	mov    rcx,rdi
   1800013d7:	48 ff 15 a2 58 04 00 	rex.W call QWORD PTR [rip+0x458a2]        # 0x180046c80
   1800013de:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   1800013e3:	48 8d 0d e6 a8 05 00 	lea    rcx,[rip+0x5a8e6]        # 0x18005bcd0
   1800013ea:	c7 44 24 40 00 00 00 	mov    DWORD PTR [rsp+0x40],0x0
   1800013f1:	00 
   1800013f2:	48 8b d8             	mov    rbx,rax
   1800013f5:	48 ff 15 64 58 04 00 	rex.W call QWORD PTR [rip+0x45864]        # 0x180046c60
   1800013fc:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   180001401:	8b 0d 29 b6 05 00    	mov    ecx,DWORD PTR [rip+0x5b629]        # 0x18005ca30
   180001407:	85 c9                	test   ecx,ecx
   180001409:	75 71                	jne    0x18000147c
   18000140b:	4d 85 f6             	test   r14,r14
   18000140e:	74 10                	je     0x180001420
   180001410:	48 8b 0d 21 b6 05 00 	mov    rcx,QWORD PTR [rip+0x5b621]        # 0x18005ca38
   180001417:	49 8b c6             	mov    rax,r14
   18000141a:	ff 15 38 5c 04 00    	call   QWORD PTR [rip+0x45c38]        # 0x180047058
   180001420:	48 8d 0d e9 fc ff ff 	lea    rcx,[rip+0xfffffffffffffce9]        # 0x180001110
   180001427:	48 85 f6             	test   rsi,rsi
   18000142a:	74 12                	je     0x18000143e
   18000142c:	48 8d 15 fd fc ff ff 	lea    rdx,[rip+0xfffffffffffffcfd]        # 0x180001130
   180001433:	48 8b c6             	mov    rax,rsi
   180001436:	ff 15 1c 5c 04 00    	call   QWORD PTR [rip+0x45c1c]        # 0x180047058
   18000143c:	eb 09                	jmp    0x180001447
   18000143e:	49 8b c7             	mov    rax,r15
   180001441:	ff 15 11 5c 04 00    	call   QWORD PTR [rip+0x45c11]        # 0x180047058
   180001447:	4c 8d 44 24 60       	lea    r8,[rsp+0x60]
   18000144c:	ba 04 01 00 00       	mov    edx,0x104
   180001451:	48 8d 0d b8 8f 05 00 	lea    rcx,[rip+0x58fb8]        # 0x18005a410
   180001458:	e8 17 ad 02 00       	call   0x18002c174
   18000145d:	48 8b 44 24 58       	mov    rax,QWORD PTR [rsp+0x58]
   180001462:	48 89 1d 5f a8 05 00 	mov    QWORD PTR [rip+0x5a85f],rbx        # 0x18005bcc8
   180001469:	48 89 05 d0 b5 05 00 	mov    QWORD PTR [rip+0x5b5d0],rax        # 0x18005ca40
   180001470:	c7 05 b6 b5 05 00 02 	mov    DWORD PTR [rip+0x5b5b6],0x2        # 0x18005ca30
   180001477:	00 00 00 
   18000147a:	eb 05                	jmp    0x180001481
   18000147c:	44 89 6c 24 40       	mov    DWORD PTR [rsp+0x40],r13d
   180001481:	48 8d 0d 48 a8 05 00 	lea    rcx,[rip+0x5a848]        # 0x18005bcd0
   180001488:	48 ff 15 d9 57 04 00 	rex.W call QWORD PTR [rip+0x457d9]        # 0x180046c68
   18000148f:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   180001494:	8b 44 24 40          	mov    eax,DWORD PTR [rsp+0x40]
   180001498:	85 c0                	test   eax,eax
   18000149a:	74 11                	je     0x1800014ad
   18000149c:	48 8b 4c 24 58       	mov    rcx,QWORD PTR [rsp+0x58]
   1800014a1:	48 ff 15 e8 57 04 00 	rex.W call QWORD PTR [rip+0x457e8]        # 0x180046c90
   1800014a8:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   1800014ad:	48 8b 5c 24 48       	mov    rbx,QWORD PTR [rsp+0x48]
   1800014b2:	eb 0d                	jmp    0x1800014c1
   1800014b4:	48 8b d7             	mov    rdx,rdi
   1800014b7:	b9 03 00 00 00       	mov    ecx,0x3
   1800014bc:	e8 f7 fc ff ff       	call   0x1800011b8
   1800014c1:	83 7c 24 50 00       	cmp    DWORD PTR [rsp+0x50],0x0
   1800014c6:	74 08                	je     0x1800014d0
   1800014c8:	48 8b cb             	mov    rcx,rbx
   1800014cb:	e8 e0 ec 01 00       	call   0x1800201b0
   1800014d0:	48 8b 8d 70 01 00 00 	mov    rcx,QWORD PTR [rbp+0x170]
   1800014d7:	48 33 cc             	xor    rcx,rsp
   1800014da:	e8 71 ac 02 00       	call   0x18002c150
   1800014df:	4c 8d 9c 24 80 02 00 	lea    r11,[rsp+0x280]
   1800014e6:	00 
   1800014e7:	49 8b 5b 20          	mov    rbx,QWORD PTR [r11+0x20]
   1800014eb:	49 8b 73 28          	mov    rsi,QWORD PTR [r11+0x28]
   1800014ef:	49 8b 7b 30          	mov    rdi,QWORD PTR [r11+0x30]
   1800014f3:	4d 8b 6b 38          	mov    r13,QWORD PTR [r11+0x38]
   1800014f7:	49 8b e3             	mov    rsp,r11
   1800014fa:	41 5f                	pop    r15
   1800014fc:	41 5e                	pop    r14
   1800014fe:	5d                   	pop    rbp
   1800014ff:	c3                   	ret    