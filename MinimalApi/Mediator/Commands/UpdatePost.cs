﻿using Domain.Models;
using MediatR;

namespace MinimalApi.Mediator.Commands;
public record UpdatePost : IRequest<Post>
{
    public int Id { get; set; }
    public string? Content { get; set; }
}