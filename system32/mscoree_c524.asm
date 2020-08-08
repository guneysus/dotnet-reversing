   18000c524:	48 8b c4             	mov    rax,rsp
   18000c527:	55                   	push   rbp
   18000c528:	41 54                	push   r12
   18000c52a:	41 55                	push   r13
   18000c52c:	41 56                	push   r14
   18000c52e:	41 57                	push   r15
   18000c530:	48 8d a8 28 f9 ff ff 	lea    rbp,[rax-0x6d8]
   18000c537:	48 81 ec b0 07 00 00 	sub    rsp,0x7b0
   18000c53e:	48 c7 45 50 fe ff ff 	mov    QWORD PTR [rbp+0x50],0xfffffffffffffffe
   18000c545:	ff 
   18000c546:	48 89 58 08          	mov    QWORD PTR [rax+0x8],rbx
   18000c54a:	48 89 70 18          	mov    QWORD PTR [rax+0x18],rsi
   18000c54e:	48 89 78 20          	mov    QWORD PTR [rax+0x20],rdi
   18000c552:	48 8b 05 07 d5 04 00 	mov    rax,QWORD PTR [rip+0x4d507]        # 0x180059a60
   18000c559:	48 33 c4             	xor    rax,rsp
   18000c55c:	48 89 85 a0 06 00 00 	mov    QWORD PTR [rbp+0x6a0],rax
   18000c563:	45 8b f0             	mov    r14d,r8d
   18000c566:	4c 8b e2             	mov    r12,rdx
   18000c569:	44 8b f9             	mov    r15d,ecx
   18000c56c:	45 33 ed             	xor    r13d,r13d
   18000c56f:	41 8b fd             	mov    edi,r13d
   18000c572:	4c 8b 15 c7 ff 04 00 	mov    r10,QWORD PTR [rip+0x4ffc7]        # 0x18005c540
   18000c579:	4c 8b 0d c8 ff 04 00 	mov    r9,QWORD PTR [rip+0x4ffc8]        # 0x18005c548
   18000c580:	48 8b 1d 01 07 05 00 	mov    rbx,QWORD PTR [rip+0x50701]        # 0x18005cc88
   18000c587:	4c 8b 1d 02 07 05 00 	mov    r11,QWORD PTR [rip+0x50702]        # 0x18005cc90
   18000c58e:	4d 85 db             	test   r11,r11
   18000c591:	74 0d                	je     0x18000c5a0
   18000c593:	e8 20 7b 00 00       	call   0x1800140b8
   18000c598:	48 3b d8             	cmp    rbx,rax
   18000c59b:	49 8b c1             	mov    rax,r9
   18000c59e:	74 03                	je     0x18000c5a3
   18000c5a0:	49 8b c2             	mov    rax,r10
   18000c5a3:	b9 01 00 00 00       	mov    ecx,0x1
   18000c5a8:	48 83 ce ff          	or     rsi,0xffffffffffffffff
   18000c5ac:	48 85 c0             	test   rax,rax
   18000c5af:	0f 85 32 02 00 00    	jne    0x18000c7e7
   18000c5b5:	0f 57 c0             	xorps  xmm0,xmm0
   18000c5b8:	66 0f 7f 44 24 30    	movdqa XMMWORD PTR [rsp+0x30],xmm0
   18000c5be:	0f 57 c9             	xorps  xmm1,xmm1
   18000c5c1:	66 0f 7f 4c 24 40    	movdqa XMMWORD PTR [rsp+0x40],xmm1
   18000c5c7:	66 0f 7f 44 24 50    	movdqa XMMWORD PTR [rsp+0x50],xmm0
   18000c5cd:	66 0f 7f 4c 24 60    	movdqa XMMWORD PTR [rsp+0x60],xmm1
   18000c5d3:	48 89 4c 24 70       	mov    QWORD PTR [rsp+0x70],rcx
   18000c5d8:	44 89 6c 24 78       	mov    DWORD PTR [rsp+0x78],r13d
   18000c5dd:	4c 89 6d 80          	mov    QWORD PTR [rbp-0x80],r13
   18000c5e1:	89 4d 88             	mov    DWORD PTR [rbp-0x78],ecx
   18000c5e4:	4c 89 6d 90          	mov    QWORD PTR [rbp-0x70],r13
   18000c5e8:	4c 89 6d 98          	mov    QWORD PTR [rbp-0x68],r13
   18000c5ec:	4c 89 6d a0          	mov    QWORD PTR [rbp-0x60],r13
   18000c5f0:	44 89 6d a8          	mov    DWORD PTR [rbp-0x58],r13d
   18000c5f4:	48 89 75 b0          	mov    QWORD PTR [rbp-0x50],rsi
   18000c5f8:	45 85 f6             	test   r14d,r14d
   18000c5fb:	75 07                	jne    0x18000c604
   18000c5fd:	45 85 ff             	test   r15d,r15d
   18000c600:	8b d1                	mov    edx,ecx
   18000c602:	75 03                	jne    0x18000c607
   18000c604:	41 8b d5             	mov    edx,r13d
   18000c607:	4d 85 db             	test   r11,r11
   18000c60a:	74 0d                	je     0x18000c619
   18000c60c:	e8 a7 7a 00 00       	call   0x1800140b8
   18000c611:	48 3b d8             	cmp    rbx,rax
   18000c614:	49 8b c1             	mov    rax,r9
   18000c617:	74 03                	je     0x18000c61c
   18000c619:	49 8b c2             	mov    rax,r10
   18000c61c:	48 85 c0             	test   rax,rax
   18000c61f:	74 08                	je     0x18000c629
   18000c621:	41 8b fd             	mov    edi,r13d
   18000c624:	e9 7c 01 00 00       	jmp    0x18000c7a5
   18000c629:	45 33 c0             	xor    r8d,r8d
   18000c62c:	48 8d 4c 24 30       	lea    rcx,[rsp+0x30]
   18000c631:	e8 ce 27 00 00       	call   0x18000ee04
   18000c636:	8b f8                	mov    edi,eax
   18000c638:	85 c0                	test   eax,eax
   18000c63a:	0f 89 49 01 00 00    	jns    0x18000c789
   18000c640:	48 8d 05 81 e5 03 00 	lea    rax,[rip+0x3e581]        # 0x18004abc8
   18000c647:	45 85 f6             	test   r14d,r14d
   18000c64a:	0f 84 b6 00 00 00    	je     0x18000c706
   18000c650:	0f 57 c0             	xorps  xmm0,xmm0
   18000c653:	66 0f 7f 45 c0       	movdqa XMMWORD PTR [rbp-0x40],xmm0
   18000c658:	0f 57 c9             	xorps  xmm1,xmm1
   18000c65b:	66 0f 7f 4d d0       	movdqa XMMWORD PTR [rbp-0x30],xmm1
   18000c660:	66 0f 7f 45 e0       	movdqa XMMWORD PTR [rbp-0x20],xmm0
   18000c665:	0f 11 4d f0          	movups XMMWORD PTR [rbp-0x10],xmm1
   18000c669:	bb 01 00 00 00       	mov    ebx,0x1
   18000c66e:	48 89 5d 00          	mov    QWORD PTR [rbp+0x0],rbx
   18000c672:	44 89 6d 08          	mov    DWORD PTR [rbp+0x8],r13d
   18000c676:	4c 89 6d 10          	mov    QWORD PTR [rbp+0x10],r13
   18000c67a:	89 5d 18             	mov    DWORD PTR [rbp+0x18],ebx
   18000c67d:	4c 89 6d 20          	mov    QWORD PTR [rbp+0x20],r13
   18000c681:	4c 89 6d 28          	mov    QWORD PTR [rbp+0x28],r13
   18000c685:	4c 89 6d 30          	mov    QWORD PTR [rbp+0x30],r13
   18000c689:	44 89 6d 38          	mov    DWORD PTR [rbp+0x38],r13d
   18000c68d:	48 89 75 40          	mov    QWORD PTR [rbp+0x40],rsi
   18000c691:	44 8b cb             	mov    r9d,ebx
   18000c694:	4c 8b c0             	mov    r8,rax
   18000c697:	48 8d 55 c8          	lea    rdx,[rbp-0x38]
   18000c69b:	e8 34 ec ff ff       	call   0x18000b2d4
   18000c6a0:	8b f8                	mov    edi,eax
   18000c6a2:	85 c0                	test   eax,eax
   18000c6a4:	79 0e                	jns    0x18000c6b4
   18000c6a6:	48 8d 4d c0          	lea    rcx,[rbp-0x40]
   18000c6aa:	e8 d1 ec ff ff       	call   0x18000b380
   18000c6af:	e9 0d 01 00 00       	jmp    0x18000c7c1
   18000c6b4:	89 5d 04             	mov    DWORD PTR [rbp+0x4],ebx
   18000c6b7:	4c 39 2d d2 05 05 00 	cmp    QWORD PTR [rip+0x505d2],r13        # 0x18005cc90
   18000c6be:	74 15                	je     0x18000c6d5
   18000c6c0:	e8 f3 79 00 00       	call   0x1800140b8
   18000c6c5:	48 39 05 bc 05 05 00 	cmp    QWORD PTR [rip+0x505bc],rax        # 0x18005cc88
   18000c6cc:	48 8b 05 75 fe 04 00 	mov    rax,QWORD PTR [rip+0x4fe75]        # 0x18005c548
   18000c6d3:	74 07                	je     0x18000c6dc
   18000c6d5:	48 8b 05 64 fe 04 00 	mov    rax,QWORD PTR [rip+0x4fe64]        # 0x18005c540
   18000c6dc:	48 85 c0             	test   rax,rax
   18000c6df:	74 05                	je     0x18000c6e6
   18000c6e1:	41 8b fd             	mov    edi,r13d
   18000c6e4:	eb 10                	jmp    0x18000c6f6
   18000c6e6:	45 33 c0             	xor    r8d,r8d
   18000c6e9:	33 d2                	xor    edx,edx
   18000c6eb:	48 8d 4d c0          	lea    rcx,[rbp-0x40]
   18000c6ef:	e8 10 27 00 00       	call   0x18000ee04
   18000c6f4:	8b f8                	mov    edi,eax
   18000c6f6:	48 8d 4d c0          	lea    rcx,[rbp-0x40]
   18000c6fa:	e8 81 ec ff ff       	call   0x18000b380
   18000c6ff:	48 8d 05 c2 e4 03 00 	lea    rax,[rip+0x3e4c2]        # 0x18004abc8
   18000c706:	85 ff                	test   edi,edi
   18000c708:	79 7f                	jns    0x18000c789
   18000c70a:	45 85 ff             	test   r15d,r15d
   18000c70d:	0f 84 ae 00 00 00    	je     0x18000c7c1
   18000c713:	45 85 f6             	test   r14d,r14d
   18000c716:	0f 84 a5 00 00 00    	je     0x18000c7c1
   18000c71c:	48 8b 4c 24 30       	mov    rcx,QWORD PTR [rsp+0x30]
   18000c721:	48 89 8d 80 02 00 00 	mov    QWORD PTR [rbp+0x280],rcx
   18000c728:	48 89 85 88 02 00 00 	mov    QWORD PTR [rbp+0x288],rax
   18000c72f:	48 8d 05 c2 e5 03 00 	lea    rax,[rip+0x3e5c2]        # 0x18004acf8
   18000c736:	48 89 85 90 02 00 00 	mov    QWORD PTR [rbp+0x290],rax
   18000c73d:	48 8b c1             	mov    rax,rcx
   18000c740:	48 f7 d8             	neg    rax
   18000c743:	1b ff                	sbb    edi,edi
   18000c745:	f7 df                	neg    edi
   18000c747:	48 8d 9d 80 02 00 00 	lea    rbx,[rbp+0x280]
   18000c74e:	48 8d 85 88 02 00 00 	lea    rax,[rbp+0x288]
   18000c755:	48 85 c9             	test   rcx,rcx
   18000c758:	48 0f 44 d8          	cmove  rbx,rax
   18000c75c:	48 8d 4c 24 30       	lea    rcx,[rsp+0x30]
   18000c761:	e8 ce ec ff ff       	call   0x18000b434
   18000c766:	44 8d 47 02          	lea    r8d,[rdi+0x2]
   18000c76a:	48 8b d3             	mov    rdx,rbx
   18000c76d:	48 8d 4c 24 30       	lea    rcx,[rsp+0x30]
   18000c772:	e8 7d 15 00 00       	call   0x18000dcf4
   18000c777:	8b f8                	mov    edi,eax
   18000c779:	85 c0                	test   eax,eax
   18000c77b:	78 44                	js     0x18000c7c1
   18000c77d:	48 8d 4c 24 30       	lea    rcx,[rsp+0x30]
   18000c782:	e8 0d 11 00 00       	call   0x18000d894
   18000c787:	eb 38                	jmp    0x18000c7c1
   18000c789:	4c 8b 0d b8 fd 04 00 	mov    r9,QWORD PTR [rip+0x4fdb8]        # 0x18005c548
   18000c790:	4c 8b 15 a9 fd 04 00 	mov    r10,QWORD PTR [rip+0x4fda9]        # 0x18005c540
   18000c797:	4c 8b 1d f2 04 05 00 	mov    r11,QWORD PTR [rip+0x504f2]        # 0x18005cc90
   18000c79e:	48 8b 1d e3 04 05 00 	mov    rbx,QWORD PTR [rip+0x504e3]        # 0x18005cc88
   18000c7a5:	4d 85 db             	test   r11,r11
   18000c7a8:	74 0a                	je     0x18000c7b4
   18000c7aa:	e8 09 79 00 00       	call   0x1800140b8
   18000c7af:	48 3b d8             	cmp    rbx,rax
   18000c7b2:	74 03                	je     0x18000c7b7
   18000c7b4:	4d 8b ca             	mov    r9,r10
   18000c7b7:	4d 85 c9             	test   r9,r9
   18000c7ba:	75 14                	jne    0x18000c7d0
   18000c7bc:	bf 05 40 00 80       	mov    edi,0x80004005
   18000c7c1:	48 8d 4c 24 30       	lea    rcx,[rsp+0x30]
   18000c7c6:	e8 b5 eb ff ff       	call   0x18000b380
   18000c7cb:	e9 70 02 00 00       	jmp    0x18000ca40
   18000c7d0:	48 8d 4c 24 30       	lea    rcx,[rsp+0x30]
   18000c7d5:	e8 a6 eb ff ff       	call   0x18000b380
   18000c7da:	4c 39 2d 17 06 05 00 	cmp    QWORD PTR [rip+0x50617],r13        # 0x18005cdf8
   18000c7e1:	0f 85 4a 02 00 00    	jne    0x18000ca31
   18000c7e7:	e8 3c 8d 00 00       	call   0x180015528
   18000c7ec:	48 85 c0             	test   rax,rax
   18000c7ef:	75 0a                	jne    0x18000c7fb
   18000c7f1:	b8 0e 00 07 80       	mov    eax,0x8007000e
   18000c7f6:	e9 47 02 00 00       	jmp    0x18000ca42
   18000c7fb:	4c 39 2d 8e 04 05 00 	cmp    QWORD PTR [rip+0x5048e],r13        # 0x18005cc90
   18000c802:	74 15                	je     0x18000c819
   18000c804:	e8 af 78 00 00       	call   0x1800140b8
   18000c809:	48 39 05 78 04 05 00 	cmp    QWORD PTR [rip+0x50478],rax        # 0x18005cc88
   18000c810:	48 8b 0d 31 fd 04 00 	mov    rcx,QWORD PTR [rip+0x4fd31]        # 0x18005c548
   18000c817:	74 07                	je     0x18000c820
   18000c819:	48 8b 0d 20 fd 04 00 	mov    rcx,QWORD PTR [rip+0x4fd20]        # 0x18005c540
   18000c820:	e8 7b 5c 00 00       	call   0x1800124a0
   18000c825:	48 8b c8             	mov    rcx,rax
   18000c828:	48 85 c0             	test   rax,rax
   18000c82b:	0f 85 d8 01 00 00    	jne    0x18000ca09
   18000c831:	48 8b 0d 40 04 05 00 	mov    rcx,QWORD PTR [rip+0x50440]        # 0x18005cc78
   18000c838:	48 85 c9             	test   rcx,rcx
   18000c83b:	74 11                	je     0x18000c84e
   18000c83d:	e8 5e 5c 00 00       	call   0x1800124a0
   18000c842:	48 8b c8             	mov    rcx,rax
   18000c845:	48 85 c0             	test   rax,rax
   18000c848:	0f 85 bb 01 00 00    	jne    0x18000ca09
   18000c84e:	bf 00 17 13 80       	mov    edi,0x80131700
   18000c853:	45 85 ff             	test   r15d,r15d
   18000c856:	0f 84 e4 01 00 00    	je     0x18000ca40
   18000c85c:	8b 0d 4a e5 04 00    	mov    ecx,DWORD PTR [rip+0x4e54a]        # 0x18005adac
   18000c862:	83 f9 ff             	cmp    ecx,0xffffffff
   18000c865:	75 13                	jne    0x18000c87a
   18000c867:	e8 38 98 01 00       	call   0x1800260a4
   18000c86c:	41 8b cd             	mov    ecx,r13d
   18000c86f:	85 c0                	test   eax,eax
   18000c871:	0f 95 c1             	setne  cl
   18000c874:	89 0d 32 e5 04 00    	mov    DWORD PTR [rip+0x4e532],ecx        # 0x18005adac
   18000c87a:	85 c9                	test   ecx,ecx
   18000c87c:	0f 85 be 01 00 00    	jne    0x18000ca40
   18000c882:	48 ff 15 47 a4 03 00 	rex.W call QWORD PTR [rip+0x3a447]        # 0x180046cd0
   18000c889:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   18000c88e:	8b d8                	mov    ebx,eax
   18000c890:	8b c8                	mov    ecx,eax
   18000c892:	48 ff 15 37 a4 03 00 	rex.W call QWORD PTR [rip+0x3a437]        # 0x180046cd0
   18000c899:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   18000c89e:	f6 c3 01             	test   bl,0x1
   18000c8a1:	0f 85 99 01 00 00    	jne    0x18000ca40
   18000c8a7:	41 be 00 02 00 00    	mov    r14d,0x200
   18000c8ad:	45 8b c6             	mov    r8d,r14d
   18000c8b0:	33 d2                	xor    edx,edx
   18000c8b2:	48 8d 8d a0 02 00 00 	lea    rcx,[rbp+0x2a0]
   18000c8b9:	e8 42 2d 03 00       	call   0x18003f600
   18000c8be:	45 8b c6             	mov    r8d,r14d
   18000c8c1:	33 d2                	xor    edx,edx
   18000c8c3:	48 8d 8d a0 04 00 00 	lea    rcx,[rbp+0x4a0]
   18000c8ca:	e8 31 2d 03 00       	call   0x18003f600
   18000c8cf:	e8 5c ee ff ff       	call   0x18000b730
   18000c8d4:	48 85 c0             	test   rax,rax
   18000c8d7:	75 0a                	jne    0x18000c8e3
   18000c8d9:	e8 ba e9 ff ff       	call   0x18000b298
   18000c8de:	e9 5d 01 00 00       	jmp    0x18000ca40
   18000c8e3:	e8 48 ee ff ff       	call   0x18000b730
   18000c8e8:	48 8b c8             	mov    rcx,rax
   18000c8eb:	bb 00 01 00 00       	mov    ebx,0x100
   18000c8f0:	44 8b cb             	mov    r9d,ebx
   18000c8f3:	4c 8d 85 a0 02 00 00 	lea    r8,[rbp+0x2a0]
   18000c8fa:	ba 03 00 00 00       	mov    edx,0x3
   18000c8ff:	48 ff 15 a2 57 05 00 	rex.W call QWORD PTR [rip+0x557a2]        # 0x1800620a8
   18000c906:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   18000c90b:	e8 20 ee ff ff       	call   0x18000b730
   18000c910:	48 8b c8             	mov    rcx,rax
   18000c913:	44 8b cb             	mov    r9d,ebx
   18000c916:	4c 8d 85 a0 04 00 00 	lea    r8,[rbp+0x4a0]
   18000c91d:	ba 02 00 00 00       	mov    edx,0x2
   18000c922:	48 ff 15 7f 57 05 00 	rex.W call QWORD PTR [rip+0x5577f]        # 0x1800620a8
   18000c929:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   18000c92e:	4c 89 6d 60          	mov    QWORD PTR [rbp+0x60],r13
   18000c932:	4c 89 6d 68          	mov    QWORD PTR [rbp+0x68],r13
   18000c936:	4c 89 75 70          	mov    QWORD PTR [rbp+0x70],r14
   18000c93a:	4c 39 2d 4f 03 05 00 	cmp    QWORD PTR [rip+0x5034f],r13        # 0x18005cc90
   18000c941:	74 15                	je     0x18000c958
   18000c943:	e8 70 77 00 00       	call   0x1800140b8
   18000c948:	48 39 05 39 03 05 00 	cmp    QWORD PTR [rip+0x50339],rax        # 0x18005cc88
   18000c94f:	48 8b 0d f2 fb 04 00 	mov    rcx,QWORD PTR [rip+0x4fbf2]        # 0x18005c548
   18000c956:	74 07                	je     0x18000c95f
   18000c958:	48 8b 0d e1 fb 04 00 	mov    rcx,QWORD PTR [rip+0x4fbe1]        # 0x18005c540
   18000c95f:	48 8b c6             	mov    rax,rsi
   18000c962:	48 ff c0             	inc    rax
   18000c965:	66 44 39 2c 41       	cmp    WORD PTR [rcx+rax*2],r13w
   18000c96a:	75 f6                	jne    0x18000c962
   18000c96c:	48 8d 8d a0 02 00 00 	lea    rcx,[rbp+0x2a0]
   18000c973:	48 ff c6             	inc    rsi
   18000c976:	66 44 39 2c 71       	cmp    WORD PTR [rcx+rsi*2],r13w
   18000c97b:	75 f6                	jne    0x18000c973
   18000c97d:	48 ff c0             	inc    rax
   18000c980:	48 03 f0             	add    rsi,rax
   18000c983:	48 8d 14 36          	lea    rdx,[rsi+rsi*1]
   18000c987:	48 8d 4d 60          	lea    rcx,[rbp+0x60]
   18000c98b:	e8 6c 76 00 00       	call   0x180013ffc
   18000c990:	48 8b d8             	mov    rbx,rax
   18000c993:	48 85 c0             	test   rax,rax
   18000c996:	74 61                	je     0x18000c9f9
   18000c998:	4c 39 2d f1 02 05 00 	cmp    QWORD PTR [rip+0x502f1],r13        # 0x18005cc90
   18000c99f:	74 15                	je     0x18000c9b6
   18000c9a1:	e8 12 77 00 00       	call   0x1800140b8
   18000c9a6:	48 39 05 db 02 05 00 	cmp    QWORD PTR [rip+0x502db],rax        # 0x18005cc88
   18000c9ad:	4c 8b 0d 94 fb 04 00 	mov    r9,QWORD PTR [rip+0x4fb94]        # 0x18005c548
   18000c9b4:	74 07                	je     0x18000c9bd
   18000c9b6:	4c 8b 0d 83 fb 04 00 	mov    r9,QWORD PTR [rip+0x4fb83]        # 0x18005c540
   18000c9bd:	4c 8d 85 a0 02 00 00 	lea    r8,[rbp+0x2a0]
   18000c9c4:	48 8b d6             	mov    rdx,rsi
   18000c9c7:	48 8b cb             	mov    rcx,rbx
   18000c9ca:	e8 09 08 02 00       	call   0x18002d1d8
   18000c9cf:	e8 ec ee ff ff       	call   0x18000b8c0
   18000c9d4:	83 c8 10             	or     eax,0x10
   18000c9d7:	c7 44 24 28 01 00 00 	mov    DWORD PTR [rsp+0x28],0x1
   18000c9de:	00 
   18000c9df:	4c 89 6c 24 20       	mov    QWORD PTR [rsp+0x20],r13
   18000c9e4:	44 8b c8             	mov    r9d,eax
   18000c9e7:	4c 8d 85 a0 04 00 00 	lea    r8,[rbp+0x4a0]
   18000c9ee:	48 8b d3             	mov    rdx,rbx
   18000c9f1:	33 c9                	xor    ecx,ecx
   18000c9f3:	e8 20 a0 01 00       	call   0x180026a18
   18000c9f8:	90                   	nop
   18000c9f9:	48 8b 4d 60          	mov    rcx,QWORD PTR [rbp+0x60]
   18000c9fd:	48 85 c9             	test   rcx,rcx
   18000ca00:	74 3e                	je     0x18000ca40
   18000ca02:	e8 a9 37 01 00       	call   0x1800201b0
   18000ca07:	eb 37                	jmp    0x18000ca40
   18000ca09:	48 8b c1             	mov    rax,rcx
   18000ca0c:	48 87 05 e5 03 05 00 	xchg   QWORD PTR [rip+0x503e5],rax        # 0x18005cdf8
   18000ca13:	48 8d 15 ee e2 03 00 	lea    rdx,[rip+0x3e2ee]        # 0x18004ad08
   18000ca1a:	48 ff 15 5f a2 03 00 	rex.W call QWORD PTR [rip+0x3a25f]        # 0x180046c80
   18000ca21:	0f 1f 44 00 00       	nop    DWORD PTR [rax+rax*1+0x0]
   18000ca26:	48 85 c0             	test   rax,rax
   18000ca29:	74 06                	je     0x18000ca31
   18000ca2b:	ff 15 27 a6 03 00    	call   QWORD PTR [rip+0x3a627]        # 0x180047058
   18000ca31:	85 ff                	test   edi,edi
   18000ca33:	78 0b                	js     0x18000ca40
   18000ca35:	48 8b 05 bc 03 05 00 	mov    rax,QWORD PTR [rip+0x503bc]        # 0x18005cdf8
   18000ca3c:	49 89 04 24          	mov    QWORD PTR [r12],rax
   18000ca40:	8b c7                	mov    eax,edi
   18000ca42:	48 8b 8d a0 06 00 00 	mov    rcx,QWORD PTR [rbp+0x6a0]
   18000ca49:	48 33 cc             	xor    rcx,rsp
   18000ca4c:	e8 ff f6 01 00       	call   0x18002c150
   18000ca51:	4c 8d 9c 24 b0 07 00 	lea    r11,[rsp+0x7b0]
   18000ca58:	00 
   18000ca59:	49 8b 5b 30          	mov    rbx,QWORD PTR [r11+0x30]
   18000ca5d:	49 8b 73 40          	mov    rsi,QWORD PTR [r11+0x40]
   18000ca61:	49 8b 7b 48          	mov    rdi,QWORD PTR [r11+0x48]
   18000ca65:	49 8b e3             	mov    rsp,r11
   18000ca68:	41 5f                	pop    r15
   18000ca6a:	41 5e                	pop    r14
   18000ca6c:	41 5d                	pop    r13
   18000ca6e:	41 5c                	pop    r12
   18000ca70:	5d                   	pop    rbp
   18000ca71:	c3                   	ret 