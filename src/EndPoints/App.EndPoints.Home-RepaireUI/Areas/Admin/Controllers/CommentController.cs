﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.AppServices.Admins;
using Microsoft.AspNetCore.Authorization;
using App.Domain.Core.DtoModels;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models;
using App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Comment;
using System.Drawing.Printing;

namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentAppservice _commentAppservice;
        private readonly IMapper _mapper;

        public CommentController(ICommentAppservice commentAppservice, IMapper mapper)
        {
            _commentAppservice = commentAppservice;
            _mapper = mapper;
        }

       
        public async Task<IActionResult> GetAllComments(CancellationToken cancellation)
        {
            var comments = await _commentAppservice.GetAll(cancellation);
            var commentViewModels = comments.Select(comment => new CommentViewModel
            {
                Id = comment.Id,
                UserId = comment.UserId,
                Comment = comment.Comment1,
                BoothId = comment.BoothId,
                BoothName = comment.Booth.Name,
                CreatedAt = comment.CreatedAt,
                IsCreated = comment.IsAccepted,
                IsDeleted = comment.IsDeleted,
                OrderId = comment.OrderId
            }).ToList();

            return View(commentViewModels);
         }
        public async Task<IActionResult> Detail(int commentId, CancellationToken cancellation)
        {
            await _commentAppservice.GetDatail(commentId, cancellation);
            return RedirectToAction("Detail");
        }
       
        public async Task<IActionResult> Active(int id, CancellationToken cancellation)
        {

            await _commentAppservice.Active(id, cancellation);
            return RedirectToAction("GetAllComments");
        }
        
        public async Task<IActionResult> Diactive(int id, CancellationToken cancellation)
        {
            await _commentAppservice.DiActive(id, cancellation);
            return RedirectToAction("GetAllComments");
        }





    }
}
