﻿using System.Collections.Generic;
using User.Example.Domain.Entities;
using User.Example.Domain.Interfaces;

namespace User.Example.Domain.UseCases
{
    public class UpdateUserUseCase : Base, IUpdateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserUseCase(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public UserEntity Execute(UserEntity request)
        {
            if (!UserExist(request.Identification))
                throw new KeyNotFoundException($"User with id {request.Identification} does not exist.");

            return _userRepository.Update(request);
        }
    }
}
